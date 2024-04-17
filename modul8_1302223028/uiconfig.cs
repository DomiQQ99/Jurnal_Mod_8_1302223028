using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302223028
{
    internal class uiconfig
    {
        public BankTransferConfig config;

        public const String filePath = "C:\\Users\\Alghifari\\Praktikum_KPL\\modul8_1302223028\\modul8_1302223028\\bin\\Debug\\net8.0\\bank_transfer_config.json";

        public uiconfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception) 
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
        public BankTransferConfig ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
            return config;
        }
        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }
        public void SetDefault()
        {
            config.lang = "en";
            config.threshold = 25000000;
            config.low_fee = 6500;
            config.high_fee = 15000;
            config.methods = ["RTO (real-time)", "SKN", "RTGS", "BI FAST"];
            config.en = "Yes";
            config.id = "Ya";

        }
    }
}
