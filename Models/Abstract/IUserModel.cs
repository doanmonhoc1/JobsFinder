using Data;

namespace Demo_1.Models
{
    public interface IUserModel
    {
        nguoi_tim_viec CheckLogin(string phoneNumber, string password);
        bool CheckContact(string phoneNumber, string Email);
    }
}