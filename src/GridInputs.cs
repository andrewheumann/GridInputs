using Elements;
using Elements.Geometry;
using Elements.Geometry.Solids;
using Elements.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridInputs
{
    public static class GridInputs
    {
        /// <summary>
        /// The GridInputs function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A GridInputsOutputs instance containing computed results and the model with any new elements.</returns>
        public static GridInputsOutputs Execute(Dictionary<string, Model> inputModels, GridInputsInputs input)
        {
            /// Your code here.
            var output = new GridInputsOutputs();
            output.Model.AddElement(input.Grid1d.Curve);
            var uGrid = new Grid1d(input.Grid1d.Curve);
            var vGrid = new Grid1d(input.OtherGrid.Curve);
            var splitPts = input.Grid1d.SplitPoints;
            uGrid.SplitAtPoints(splitPts);
            vGrid.SplitAtPoints(input.OtherGrid.SplitPoints);
            input.Grid1d.SplitPoints.Union(input.OtherGrid.SplitPoints).ToList().ForEach((pt) =>
            {
                var circle = Polygon.Ngon(20, 0.05);
                var mc = new ModelCurve(circle, BuiltInMaterials.Black, new Transform(pt));
                mc.SetSelectable(false);
                output.Model.AddElement(mc);
            });
            var grid2d = new Grid2d(uGrid, vGrid);
            var rand = new Random(5);
            var panels = grid2d.GetCells().Select(c => c.GetCellGeometry() as Polygon).Select(p => new Panel(p, rand.NextMaterial()));
            // var edges = uGrid.GetCells().Select(c => c.GetCellGeometry() as Line);
            // output.Model.AddElements(edges.Select(e => new Panel(new Polygon(new[] { e.Start, e.End, e.End + new Vector3(0, 0, 2), e.Start + new Vector3(0, 0, 2) }), rand.NextMaterial())));
            output.Model.AddElements(panels);

            // grid 2d input
            var g2dinput = input.Grid2d;
            var U = new Grid1d(g2dinput.U.Curve);
            var V = new Grid1d(g2dinput.V.Curve);
            var grid2dFromInput = new Grid2d(U, V);
            U.SplitAtPoints(g2dinput.U.SplitPoints);
            V.SplitAtPoints(g2dinput.V.SplitPoints);
            var mcs = grid2dFromInput.ToModelCurves();
            foreach (var mc in mcs)
            {
                mc.SetSelectable(false);
            }
            output.Model.AddElements(mcs);


            // 1d grid overrides

            var rectangle = Polygon.Rectangle(10, 20);
            List<GridAxisControl> gacs = new List<GridAxisControl>();
            foreach (var seg in rectangle.Segments())
            {
                var representation = new Representation(new[] { new Lamina(new Polygon(new[] { seg.Start, seg.End, seg.End + new Vector3(0, 0, 2), seg.Start + new Vector3(0, 0, 2) }), false) });
                var gac = new GridAxisControl(
                    new Grid1dInput(
                            seg.ToPolyline(1),
                            new List<Vector3> { seg.PointAt(0.5) },
                            Elements.Grid1dInputSubdivisionMode.Manual,
                            new Elements.SubdivisionSettings(1, seg.Length(), seg.Length(),
                            Elements.SubdivisionSettingsRemainderMode.Remainder_at_both_ends,
                            Elements.SubdivisionSettingsCycleMode.Cycle)
                        ),
                        seg.PointAt(0.5),
                        new Transform(), BuiltInMaterials.Mass, representation, false, Guid.NewGuid(), null);
                gacs.Add(gac);
            }

            if (input.Overrides != null && input.Overrides.Grids != null)
            {
                foreach (var gridOverride in input.Overrides.Grids)
                {
                    var matchingGac = gacs.OrderBy(g => g.RoughPosition.DistanceTo(gridOverride.Identity.RoughPosition)).First();
                    matchingGac.Grid = gridOverride.Value.Grid;
                }
            }

            foreach (var gac in gacs)
            {
                var u = new Grid1d(gac.Grid.Curve);
                u.SplitAtPoints(gac.Grid.SplitPoints);
                foreach (var cell in u.GetCells())
                {
                    var line = cell.GetCellGeometry() as Line;
                    var geo = new Polygon(new[] { line.Start, line.End, line.End + new Vector3(0, 0, 2), line.Start + new Vector3(0, 0, 2) });
                    var mc = new ModelCurve(geo);
                    mc.SetSelectable(false);
                    output.Model.AddElement(mc);
                }
            }
            output.Model.AddElements(gacs);


            // 2d grid overrides

            var rectangle2 = Polygon.Rectangle(new Vector3(40, 0), new Vector3(30, 10));
            List<GridAxisControl2d> gacs2d = new List<GridAxisControl2d>();
            foreach (var seg in rectangle2.Segments())
            {
                var heightVec = new Vector3(0, 0, 10);
                var representation = new Representation(new[] { new Lamina(new Polygon(new[] { seg.Start, seg.End, seg.End + heightVec, seg.Start + heightVec }), false) });
                var verticalSeg = new Line(seg.Start, seg.Start + heightVec);
                var gac = new GridAxisControl2d(
                    new Grid2dInput(
                        new Grid1dInput(
                            seg.ToPolyline(1),
                            new List<Vector3> { },
                            Elements.Grid1dInputSubdivisionMode.Manual,
                            new Elements.SubdivisionSettings(
                                1,
                                seg.Length(),
                                seg.Length(),
                            Elements.SubdivisionSettingsRemainderMode.Remainder_at_both_ends,
                            Elements.SubdivisionSettingsCycleMode.Cycle)
                        ),
                        new Grid1dInput(
                            verticalSeg.ToPolyline(1),
                            new List<Vector3> { },
                            Elements.Grid1dInputSubdivisionMode.Manual,
                            new Elements.SubdivisionSettings(1, verticalSeg.Length(), verticalSeg.Length(),
                             Elements.SubdivisionSettingsRemainderMode.Remainder_at_both_ends,
                            Elements.SubdivisionSettingsCycleMode.Cycle)
                        )
                    ), seg.PointAt(0.5), null, BuiltInMaterials.Mass, representation);
                gacs2d.Add(gac);
            }

            if (input.Overrides != null && input.Overrides.DGrids != null)
            {
                foreach (var gridOverride in input.Overrides.DGrids)
                {
                    var matchingGac = gacs2d.OrderBy(g => g.RoughPosition.DistanceTo(gridOverride.Identity.RoughPosition)).First();
                    matchingGac.Grid = gridOverride.Value.Grid;
                }
            }

            foreach (var gac in gacs2d)
            {
                var u = new Grid1d(gac.Grid.U.Curve);
                var v = new Grid1d(gac.Grid.V.Curve);
                var g2d = new Grid2d(u, v);
                u.SplitAtPoints(gac.Grid.U.SplitPoints);
                v.SplitAtPoints(gac.Grid.V.SplitPoints);
                foreach (var cell in g2d.GetCells())
                {
                    var pgon = cell.GetCellGeometry() as Polygon;
                    var normal = pgon.Normal();
                    var transform = new Transform().Moved(normal * 0.01);
                    output.Model.AddElement(new Panel(pgon, rand.NextMaterial(), transform));
                }
            }
            output.Model.AddElements(gacs2d);

            return output;
        }
    }
}