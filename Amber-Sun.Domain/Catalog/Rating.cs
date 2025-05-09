namespace Amber.Sun.Domain.Catalog;

public class Rating 
{
    public int Id {get; set; }
    public int Star{get; set;}
    public string? Username{get; set;} 

    public string? Review{get; set;}

    public Rating(int stars, string Username, string review) {

if (stars < 1 || stars > 5) 
{
    throw new ArgumentException("Star rating must be an integer of: 1, 2, 3, 4, 5.");

    }
if (string.IsNullOrEmpty(Username)) {
    throw new ArgumentException("Username cannot be null.");
    }
    this.Star = stars;
    this.Username = Username;
    this.Review = review;
    }
}