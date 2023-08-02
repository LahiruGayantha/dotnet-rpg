
namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id = 1, Name = "Lahiru"}
        };

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ServiceResponse<List<GetCharacterDTO>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(character => character.Id) + 1;
            characters.Add(character);
            return new ServiceResponse<List<GetCharacterDTO>>
            {
                Data = characters.Select(character => _mapper.Map<GetCharacterDTO>(character)).ToList(),
                Message = "New character has been created"
            };
        }

        public ServiceResponse<List<GetCharacterDTO>> GetAllCharacters()
        {
            return new ServiceResponse<List<GetCharacterDTO>>
            {
                Data = characters.Select(character => _mapper.Map<GetCharacterDTO>(character)).ToList()
            };
        }

        public ServiceResponse<GetCharacterDTO> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(character => character.Id == id);

            if (character is not null)
            {
                return new ServiceResponse<GetCharacterDTO>
                {
                    Data = _mapper.Map<GetCharacterDTO>(character)
                };
            }

            throw new Exception("Following ID does not found : " + id);
        }

        public ServiceResponse<GetCharacterDTO> UpdateCharacter(UpdateCharacterDTO updateCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var character = characters.FirstOrDefault(character => character.Id == updateCharacter.Id);
            if (character is not null)
            {
                _mapper.Map(updateCharacter, character); 
                serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);
                serviceResponse.Message = "Character has updated successfully";
                return serviceResponse;
            }

            serviceResponse.Success = false;
            serviceResponse.Message = "ID cannot be found";
            return serviceResponse;
        }
    }
}