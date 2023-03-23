// This file was automatically generated by VS extension Windows Machine Learning Code Generator v3
// from model file SAND.onnx
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
    
    public sealed class SANDInput
    {
        public TensorFloat serving_default_input_100; // shape(-1,154)
    }
    
    public sealed class SANDOutput
    {
        public TensorFloat StatefulPartitionedCall00; // shape(-1,1)
    }
    
    public sealed class SANDModel
    {
        private LearningModel model;
        private LearningModelSession session;
        private LearningModelBinding binding;
        public static async Task<SANDModel> CreateFromStreamAsync(IRandomAccessStreamReference stream)
        {
            SANDModel learningModel = new SANDModel();
            learningModel.model = await LearningModel.LoadFromStreamAsync(stream);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }
        public async Task<SANDOutput> EvaluateAsync(SANDInput input)
        {
            binding.Bind("serving_default_input_1:0", input.serving_default_input_100);
            var result = await session.EvaluateAsync(binding, "0");
            var output = new SANDOutput();
            output.StatefulPartitionedCall00 = result.Outputs["StatefulPartitionedCall:0"] as TensorFloat;
            return output;
        }
    }
}

