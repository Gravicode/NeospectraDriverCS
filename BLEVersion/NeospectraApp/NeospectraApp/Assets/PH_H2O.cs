// This file was automatically generated by VS extension Windows Machine Learning Code Generator v3
// from model file PH_H2O.onnx
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
    
    public sealed class PH_H2OInput
    {
        public TensorFloat serving_default_input_400; // shape(-1,154)
    }
    
    public sealed class PH_H2OOutput
    {
        public TensorFloat StatefulPartitionedCall00; // shape(-1,1)
    }
    
    public sealed class PH_H2OModel
    {
        private LearningModel model;
        private LearningModelSession session;
        private LearningModelBinding binding;
        public static async Task<PH_H2OModel> CreateFromStreamAsync(IRandomAccessStreamReference stream)
        {
            PH_H2OModel learningModel = new PH_H2OModel();
            learningModel.model = await LearningModel.LoadFromStreamAsync(stream);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }
        public async Task<PH_H2OOutput> EvaluateAsync(PH_H2OInput input)
        {
            binding.Bind("serving_default_input_4:0", input.serving_default_input_400);
            var result = await session.EvaluateAsync(binding, "0");
            var output = new PH_H2OOutput();
            output.StatefulPartitionedCall00 = result.Outputs["StatefulPartitionedCall:0"] as TensorFloat;
            return output;
        }
    }
}

