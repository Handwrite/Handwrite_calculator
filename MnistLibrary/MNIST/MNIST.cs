using Microsoft.ML.Scoring;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MnistModleLibrary
{
    public partial class Mnist
    {
        const string modelName = "BearModel";
        private ModelManager manager;

        private static List<string> inferInputNames = new List<string> { "data" };
        private static List<string> inferOutputNames = new List<string> { "classLabel" };

        /// <summary>
        /// Returns an instance of BearModel model.
        /// </summary>
        public  Mnist()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string dllpath = Uri.UnescapeDataString(uri.Path);
            string modelpath = Path.Combine(Path.GetDirectoryName(dllpath), "Mnist");
            string path = Path.Combine(modelpath, "00000001");
            manager = new ModelManager(path, true);
            manager.InitModel(modelName, int.MaxValue);
        }

        /// <summary>
        /// Returns instance of BearModel model instantiated from exported model path.
        /// </summary>
        /// <param name="path">Exported model directory.</param>
        public void BearModel(string path)
        {
            manager = new ModelManager(path, true);
            manager.InitModel(modelName, int.MaxValue);
        }

        /// <summary>
        /// Runs inference on BearModel model for a batch of inputs.
        /// The shape of each input is the same as that for the non-batch case above.
        /// </summary>
        public IEnumerable<IEnumerable<string>> Infer(IEnumerable<IEnumerable<float>> dataBatch)
        {
            List<float> dataCombined = new List<float>();
            foreach (var input in dataBatch)
            {
                dataCombined.AddRange(input);
            }

            List<Tensor> result = manager.RunModel(
                modelName,
                int.MaxValue,
                inferInputNames,
                new List<Tensor> {new Tensor(dataCombined, new List<long> {dataBatch.LongCount(), 3, 227, 227})
                },
                inferOutputNames
            );

            List<string> r0 = new List<string>();
            result[0].CopyTo(r0);

            List<List<string>> results = new List<List<string>>();
            results.Add(r0);

            return results;
        }
    } // END OF CLASS
} // END OF NAMESPACE
