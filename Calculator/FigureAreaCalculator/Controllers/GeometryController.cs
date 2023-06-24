using FigureAreaCalculator.Services.Geometry;
using FigureAreaCalculator.Services.Geometry.Exceptions;
using FigureAreaCalculator.Services.Geometry.Figures;
using FigureAreaCalculator.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FigureAreaCalculator.Controllers
{
    public class GeometryController : Controller
    {
        private readonly IGeometryService _geometryService;
        
        public GeometryController(IGeometryService geometryService)
        {
            _geometryService = geometryService;
        }

        [HttpGet("/geometry/area-size/")]
        public IActionResult FigureArea(float[] figureParams, GeometryType? geometryType = null)
        {
            try
            {
                IFigure figure;
                if (geometryType.HasValue)
                {
                    var type = geometryType.Value;
                    figure = _geometryService.CreateFigure(type, figureParams);
                }
                else
                {
                    figure = _geometryService.CreateFigure(figureParams);
                }

                var area = figure.GetAreaValue();
                return View(new GeometryViewModel(figure.FigureType, area));
            }
            catch (FigureParamsFormatException)
            {
                return BadRequest();
            }
        }
    }
}