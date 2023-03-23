// This file was automatically generated by VS extension Windows Machine Learning Code Generator v3
// from model file Jumlah.onnx
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
    
    public sealed class JumlahInput
    {
        public TensorFloat serving_default_input_1900; // shape(-1,154)
    }
    
    public sealed class JumlahOutput
    {
        public TensorFloat StatefulPartitionedCall00; // shape(-1,1)
    }
    
    public sealed class JumlahModel
    {
        private LearningModel model;
        private LearningModelSession session;
        private LearningModelBinding binding;
        public static async Task<JumlahModel> CreateFromStreamAsync(IRandomAccessStreamReference stream)
        {
            JumlahModel learningModel = new JumlahModel();
            learningModel.model = await LearningModel.LoadFromStreamAsync(stream);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }
        public async Task<JumlahOutput> EvaluateAsync(JumlahInput input)
        {
            binding.Bind("serving_default_input_19:0", input.serving_default_input_1900);
            var result = await session.EvaluateAsync(binding, "0");
            var output = new JumlahOutput();
            output.StatefulPartitionedCall00 = result.Outputs["StatefulPartitionedCall:0"] as TensorFloat;
            return output;
        }
        public static async Task<JumlahModel> LoadModelAsync(string modelFileName)
        {
            var modelPath = $"ms-appx:///Assets/{modelFileName}";
            JumlahModel learningModel = new JumlahModel();
            // Load and create the model
            var modelFile = await StorageFile.GetFileFromApplicationUriAsync(
                new Uri(modelPath));
            learningModel.model = await LearningModel.LoadFromStorageFileAsync(modelFile);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }

        public async Task<float> ProcessOutputAsync(JumlahOutput evalOutput)
        {
            // Get the label and loss from the output
            var label = evalOutput.StatefulPartitionedCall00.GetAsVectorView()[0];
            // Format the output string
            string score = $"{nameof(JumlahOutput)} => {label}";

            Debug.WriteLine(score); return label;

        }
    }
}

