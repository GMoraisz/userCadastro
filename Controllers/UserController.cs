using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UserCadastro.Models;
using UserCadastro.Repositorys;
using UserCadastro.Repositorys.Interface;

namespace UserCadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) {

            _userRepository = userRepository;




        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> GetById(int id)
        {
            UserModel user = await _userRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Cadastrar([FromBody] UserModel usermodel)
        {

            UserModel user = await _userRepository.AddUser(usermodel);

            return Ok(user);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Atualizar([FromBody] UserModel usermodel, int id)
        {

            usermodel.Id = id;
            UserModel user = await _userRepository.AttUser(usermodel, id);

            return Ok(user);
        }

        [HttpDelete("{id}")]

       
        public async Task<ActionResult<UserModel>> Apagar(int id)
        {

            bool deleted = await _userRepository.DeleteUser(id);

            return Ok(deleted);


        } } }
