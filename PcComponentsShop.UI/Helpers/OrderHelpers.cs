namespace PcComponentsShop.UI.Helpers
{
    public static class OrderHelpers
    {
        public static void GetOrderWordAndColor(string orderStatus, out string word, out string color)
        {
            switch (orderStatus)
            {
                case ("Registered"):
                    color= "bg-warning";
                    word = "Зарегестрирован";
                    break;
                case ("Paid"):
                    color= "bg-success";
                    word = "Оплачен";
                    break;
                case ("Finished"):
                    color= "bg-dark";
                    word = "Завершен";
                    break;
                default:
                    color= "bg-danger";
                    word = "Отменен";
                    break;
            }
        }
    }
}