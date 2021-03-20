namespace OnlineShop.Models
{
    public interface IRegisterViewModel
    {
        string ConfirmPassword { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}