using UserCadastro.Models;

namespace UserCadastro.Repositorys.Interface
{
    public interface IUserRepository
    {
       

        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetById(int id);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> AttUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);


    }
}
