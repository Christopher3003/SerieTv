namespace ITLATv.WebApp.Middleware
{
    public class ConvertToEmbedYTVideo
    {
        public string ConverterToEmbed(string videoUrl)
        {
            if (videoUrl.Contains("www.youtube.com"))
            {
               
                videoUrl = videoUrl.Replace("watch?v=", "embed/");      
            }
            else
            {
                videoUrl = videoUrl.Replace("youtu.be", "www.youtube.com/embed");
            }

            return videoUrl;
        }
    }
}
