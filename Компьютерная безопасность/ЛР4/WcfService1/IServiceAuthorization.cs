using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Security.Cryptography;
using System.ServiceModel.Web;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceAuthorization" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServiceAuthorization
    {
        [OperationContract]
        [WebGet(UriTemplate = "requests?country={country}&status={status}")]
        [WebInvoke(Method = "POST", UriTemplate = "requests")]
        bool AccessAction(string token, int rights);

        [OperationContract]
        [WebGet(UriTemplate = "requests?country={country}&status={status}")]
        [WebInvoke(Method = "POST", UriTemplate = "requests")]
        string Authentication(string login, string password);

        [OperationContract]
        [WebGet(UriTemplate = "requests?country={country}&status={status}")]
        [WebInvoke(Method = "POST", UriTemplate = "requests")]
        RSAParameters MakeCryptoKey();
    }
}
