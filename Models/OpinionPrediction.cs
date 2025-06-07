using Microsoft.ML.Data;

namespace Práctica4_JeanEstrada.Models
{
    public class OpinionPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }
        public float Probability { get; set; }
        public float Score { get; set; }
    }
}
