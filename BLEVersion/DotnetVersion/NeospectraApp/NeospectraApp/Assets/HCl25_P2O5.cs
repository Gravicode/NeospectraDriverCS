// This file was automatically generated by VS extension Windows Machine Learning Code Generator v3
// from model file HCl25_P2O5.onnx
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
    
    public sealed class HCl25_P2O5Input
    {
        public TensorFloat serving_default_input_900; // shape(-1,154)
    }
    
    public sealed class HCl25_P2O5Output
    {
        public TensorFloat StatefulPartitionedCall00; // shape(-1,1)
    }
    
    public sealed class HCl25_P2O5Model
    {
        private LearningModel model;
        private LearningModelSession session;
        private LearningModelBinding binding;
        public static async Task<HCl25_P2O5Model> CreateFromStreamAsync(IRandomAccessStreamReference stream)
        {
            HCl25_P2O5Model learningModel = new HCl25_P2O5Model();
            learningModel.model = await LearningModel.LoadFromStreamAsync(stream);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }
        public async Task<HCl25_P2O5Output> EvaluateAsync(HCl25_P2O5Input input)
        {
            binding.Bind("serving_default_input_9:0", input.serving_default_input_900);
            var result = await session.EvaluateAsync(binding, "0");
            var output = new HCl25_P2O5Output();
            output.StatefulPartitionedCall00 = result.Outputs["StatefulPartitionedCall:0"] as TensorFloat;
            return output;
        }
    }
}

