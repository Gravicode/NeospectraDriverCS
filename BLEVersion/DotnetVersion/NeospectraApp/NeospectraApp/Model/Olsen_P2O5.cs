// This file was automatically generated by VS extension Windows Machine Learning Code Generator v3
// from model file Olsen_P2O5.onnx
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
    
    public sealed class Olsen_P2O5Input
    {
        public TensorFloat serving_default_input_1100; // shape(-1,154)
    }
    
    public sealed class Olsen_P2O5Output
    {
        public TensorFloat StatefulPartitionedCall00; // shape(-1,1)
    }
    
    public sealed class Olsen_P2O5Model
    {
        private LearningModel model;
        private LearningModelSession session;
        private LearningModelBinding binding;
        public static async Task<Olsen_P2O5Model> CreateFromStreamAsync(IRandomAccessStreamReference stream)
        {
            Olsen_P2O5Model learningModel = new Olsen_P2O5Model();
            learningModel.model = await LearningModel.LoadFromStreamAsync(stream);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }
        public async Task<Olsen_P2O5Output> EvaluateAsync(Olsen_P2O5Input input)
        {
            binding.Bind("serving_default_input_11:0", input.serving_default_input_1100);
            var result = await session.EvaluateAsync(binding, "0");
            var output = new Olsen_P2O5Output();
            output.StatefulPartitionedCall00 = result.Outputs["StatefulPartitionedCall:0"] as TensorFloat;
            return output;
        }
        public static async Task<Olsen_P2O5Model> LoadModelAsync(string modelFileName)
        {
            var modelPath = $"ms-appx:///Assets/{modelFileName}";
            Olsen_P2O5Model learningModel = new Olsen_P2O5Model();
            // Load and create the model
            var modelFile = await StorageFile.GetFileFromApplicationUriAsync(
                new Uri(modelPath));
            learningModel.model = await LearningModel.LoadFromStorageFileAsync(modelFile);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }

        public async Task<float> ProcessOutputAsync(Olsen_P2O5Output evalOutput)
        {
            // Get the label and loss from the output
            var label = evalOutput.StatefulPartitionedCall00.GetAsVectorView()[0];
            // Format the output string
            string score = $"{nameof(Olsen_P2O5Output)} => {label}";

            Debug.WriteLine(score); return label;

        }
    }
}

