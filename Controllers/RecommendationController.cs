using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Práctica4_JeanEstrada.Models;

namespace Práctica4_JeanEstrada.Controllers
{
    public class RecommendationController : Controller
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _model;

        public RecommendationController()
        {
            _mlContext = new MLContext();
            var modelPath = Path.Combine(Directory.GetCurrentDirectory(), "MLModels", "recommendation-model.zip");
            _model = _mlContext.Model.Load(modelPath, out _);
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(string userId)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<RatingInput, ProductRecommendation>(_model);

            var productIds = new[] { "P1", "P2", "P3", "P4", "P5" };

            var recomendaciones = productIds
                .Select(pid => new ProductRecommendation
                {
                    ProductId = pid,
                    Score = predictionEngine.Predict(new RatingInput { UserId = userId, ProductId = pid }).Score
                })
                .OrderByDescending(r => r.Score)
                .Take(5)
                .ToList();

            ViewBag.Recomendaciones = recomendaciones;
            ViewBag.Usuario = userId;
            return View();
        }
    }
}
