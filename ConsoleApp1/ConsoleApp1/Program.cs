DateTime GetDate()
{
    var dateTime = DateTime.UtcNow;
    Console.WriteLine( dateTime.ToString());
    return dateTime;
}

void DateSubtruct(DateTime startDate)
{
    var dateTime = DateTime.UtcNow;
    var dateDifference = dateTime.Subtract(startDate);
    Console.WriteLine($"You completed it in {dateDifference.ToString(@"mm\:ss\:f")}");
    

}
