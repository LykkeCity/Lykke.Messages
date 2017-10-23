using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Messages.Email
{
    internal interface ITemplateDataValidator
    {
        Task AssertValid(string templateId, IDictionary<string, string> msgData);
    }
}