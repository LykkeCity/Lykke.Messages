using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureStorage;
using Lykke.SettingsReader;

namespace Lykke.Messages.Email
{
    public class JsonSchemaTemplateDataValidator : ITemplateDataValidator
    {
        public JsonSchemaTemplateDataValidator(IBlobStorage blob, string containerName)
        {
        }

        public Task AssertValid(string templateId, IDictionary<string, string> msgData)
        {
            throw new NotImplementedException();
        }
    }
}