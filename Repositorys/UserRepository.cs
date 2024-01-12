using Microsoft.EntityFrameworkCore;
using UserCadastro.Data;
using UserCadastro.Models;
using UserCadastro.Repositorys.Interface;

namespace UserCadastro.Repositorys
{
    public class UserRepository : IUserRepository
    {

        private readonly SystemUserRegistersDBContext _DBContext;
        public UserRepository(SystemUserRegistersDBContext systemUserRegistersDBContext) {

            _DBContext = systemUserRegistersDBContext;
        }


        public async Task<UserModel> GetById(int id)
        {
            return await _DBContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _DBContext.Users.ToListAsync();
        }


        public async Task<UserModel> AddUser(UserModel user)
        {
            await _DBContext.Users.AddAsync(user);
            await _DBContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> AttUser(UserModel user, int id)
        {

            UserModel userById = await GetById(id);
            if (userById == null) {
                throw new Exception("O Usuario para o ID:{id} nao foi encontrado no banco de dados.");


            }
            userById.Nome = user.Nome;
            userById.Sobrenome = user.Sobrenome;
            userById.Apelido = user.Apelido;

            _DBContext.Users.Update(userById);
            await _DBContext.SaveChangesAsync();
            
            return userById;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception("O Usuario para o ID:{id} nao foi encontrado no banco de dados.");


            }

            _DBContext.Users.Remove(userById);
            await _DBContext.SaveChangesAsync();
            return true;

        }
    } }
