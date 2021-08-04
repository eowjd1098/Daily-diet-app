using System.ServiceModel;

namespace Service
{
    [ServiceContract]   
    public interface IService
    {
        // 리눅스용 서비스 
        [OperationContract]
        bool ConnectTest();

        [OperationContract]
        int AddMember(string id, string pw, string name,string age, string gender);

        [OperationContract]
        int Login(string id, string pw);

        [OperationContract]
        FoodNutrient ImageAnalysis(string id, byte[] img);

        [OperationContract]
        FoodNutrient LoadEatFood(string id, string date);
        
    }

}
