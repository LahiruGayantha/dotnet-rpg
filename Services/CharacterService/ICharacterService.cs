namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        ServiceResponse<List<GetCharacterDTO>> GetAllCharacters();
        ServiceResponse<GetCharacterDTO> GetCharacterById(int id);
        ServiceResponse<List<GetCharacterDTO>> AddCharacter(AddCharacterDTO newCharacter);
        ServiceResponse<GetCharacterDTO> UpdateCharacter(UpdateCharacterDTO updateCharacter);
    }
}