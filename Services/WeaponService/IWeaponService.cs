using RPGWebAPI.Dtos;
using RPGWebAPI.Dtos.Weapon;
using RPGWebAPI.Models;

namespace RPGWebAPI.Services.WeaponService;

public interface IWeaponService
{
    Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
}
