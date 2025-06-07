using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Práctica4_JeanEstrada.Models; // Ajusta según tu namespace real

namespace Práctica4_JeanEstrada.Controllers
{
    public class SentimentController : Controller
    {
        private readonly PredictionEngine<OpinionModel, OpinionPrediction> _engine;

        public SentimentController()
        {
            var mlContext = new MLContext();
            var modelPath = Path.Combine(Directory.GetCurrentDirectory(), "MLModels", "sentiment-model.zip");
            var model = mlContext.Model.Load(modelPath, out _);
            _engine = mlContext.Model.CreatePredictionEngine<OpinionModel, OpinionPrediction>(model);
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(OpinionModel input)
        {
            var resultado = _engine.Predict(input);
            ViewBag.Resultado = resultado.Prediction ? "Opinión Positiva" : "Opinión Negativa";
            ViewBag.Probabilidad = resultado.Probability;
            return View();
        }
    }
}
