// This file was automatically generated by VS extension Windows Machine Learning Code Generator v3
// from model file K.onnx
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
    
    public sealed class KInput
    {
        public TensorFloat serving_default_input_1700; // shape(-1,154)
    }
    
    public sealed class KOutput
    {
        public TensorFloat StatefulPartitionedCall00; // shape(-1,1)
    }
    
    public sealed class KModel
    {
        private LearningModel model;
        private LearningModelSession session;
        private LearningModelBinding binding;
        public static async Task<KModel> CreateFromStreamAsync(IRandomAccessStreamReference stream)
        {
            KModel learningModel = new KModel();
            learningModel.model = await LearningModel.LoadFromStreamAsync(stream);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }
        public async Task<KOutput> EvaluateAsync(KInput input)
        {
            binding.Bind("serving_default_input_17:0", input.serving_default_input_1700);
            var result = await session.EvaluateAsync(binding, "0");
            var output = new KOutput();
            output.StatefulPartitionedCall00 = result.Outputs["StatefulPartitionedCall:0"] as TensorFloat;
            return output;
        }
    }
}

