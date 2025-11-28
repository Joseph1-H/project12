using Model;
using System.ServiceModel;

namespace WCFServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //====================================================== 
        // Admins 
        // ===================================================== 
        [OperationContract]
        AdminsList AdminsSelectAll();
        [OperationContract]
        AdminsRec AdminsSelect(long id);
        [OperationContract]
        bool AdminsInsert(AdminsRec admin);
        [OperationContract]
        bool AdminsUpdate(AdminsRec admin);
        [OperationContract]
        bool AdminsDelete(long id);
        //[OperationContract]
        // UserLogged AdminsInsertWithPassword(AdminsRec admin, PasswordsRec password);
    }
}
