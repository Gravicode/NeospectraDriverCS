// This file was automatically generated by VS extension Windows Machine Learning Code Generator v3
// from model file WBC.onnx
// Warning: This file may get overwritten if you add add an onnx file with the same name
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Media;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.AI.MachineLearning;
using System.Diagnostics;

namespace NeospectraApp
{
    
    public sealed class WBCInput
    {
        public TensorFloat serving_default_input_600; // shape(-1,154)
    }
    
    public sealed class WBCOutput
    {
        public TensorFloat StatefulPartitionedCall00; // shape(-1,1)
    }
    
    public sealed class WBCModel
    {
        private LearningModel model;
        private LearningModelSession session;
        private LearningModelBinding binding;
        public static async Task<WBCModel> CreateFromStreamAsync(IRandomAccessStreamReference stream)
        {
            WBCModel learningModel = new WBCModel();
            learningModel.model = await LearningModel.LoadFromStreamAsync(stream);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }
        public async Task<WBCOutput> EvaluateAsync(WBCInput input)
        {
            binding.Bind("serving_default_input_6:0", input.serving_default_input_600);
            var result = await session.EvaluateAsync(binding, "0");
            var output = new WBCOutput();
            output.StatefulPartitionedCall00 = result.Outputs["StatefulPartitionedCall:0"] as TensorFloat;
            return output;
        }
        public static async Task<WBCModel> LoadModelAsync(string modelFileName)
        {
            var modelPath = $"ms-appx:///Assets/{modelFileName}";
            WBCModel learningModel = new WBCModel();
            // Load and create the model
            var modelFile = await StorageFile.GetFileFromApplicationUriAsync(
                new Uri(modelPath));
            learningModel.model = await LearningModel.LoadFromStorageFileAsync(modelFile);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }

        public async Task<float> ProcessOutputAsync(WBCOutput evalOutput)
        {
            // Get the label and loss from the output
            var label = evalOutput.StatefulPartitionedCall00.GetAsVectorView()[0];
            // Format the output string
            string score = $"{nameof(WBCOutput)} => {label}";

            Debug.WriteLine(score); return label;

        }
    }
}

