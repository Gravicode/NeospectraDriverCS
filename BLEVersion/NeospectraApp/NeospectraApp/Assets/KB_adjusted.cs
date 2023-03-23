// This file was automatically generated by VS extension Windows Machine Learning Code Generator v3
// from model file KB_adjusted.onnx
// Warning: This file may get overwritten if you add add an onnx file with the same name
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Media;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.AI.MachineLearning;
namespace NeospectraApp
{
    
    public sealed class KB_adjustedInput
    {
        public TensorFloat serving_default_input_2100; // shape(-1,154)
    }
    
    public sealed class KB_adjustedOutput
    {
        public TensorFloat StatefulPartitionedCall00; // shape(-1,1)
    }
    
    public sealed class KB_adjustedModel
    {
        private LearningModel model;
        private LearningModelSession session;
        private LearningModelBinding binding;
        public static async Task<KB_adjustedModel> CreateFromStreamAsync(IRandomAccessStreamReference stream)
        {
            KB_adjustedModel learningModel = new KB_adjustedModel();
            learningModel.model = await LearningModel.LoadFromStreamAsync(stream);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }
        public async Task<KB_adjustedOutput> EvaluateAsync(KB_adjustedInput input)
        {
            binding.Bind("serving_default_input_21:0", input.serving_default_input_2100);
            var result = await session.EvaluateAsync(binding, "0");
            var output = new KB_adjustedOutput();
            output.StatefulPartitionedCall00 = result.Outputs["StatefulPartitionedCall:0"] as TensorFloat;
            return output;
        }
    }
}

