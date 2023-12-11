using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System.Net;
using System.Net.Mail;


//SMTP();
IMAP();
void SMTP()
{
    var client = new SmtpClient("smtp.gmail.com", 587);
    client.EnableSsl = true;
    client.Credentials = new NetworkCredential(
        "zamanov@itstep.org",
        "your_google_app_password"
        );

    var message = new MailMessage()
    {
        Subject = "For test",
        Body = "Lorem ipsum dolor sit amet"
    };

    message.From = new MailAddress("zamanov@itstep.org", "Cadudu achma");
    message.To.Add(new MailAddress("nurlanjavadzada@gmail.com"));
    message.To.Add(new MailAddress("imaneyvazov2@gmail.com"));
    message.To.Add(new MailAddress("seymur.amiraslanov313@gmail.com"));

    client.Send(message);

}

void IMAP()
{
    var imapClient = new ImapClient();
    imapClient.Connect("imap.gmail.com", 993, true);

    imapClient.Authenticate(
        "zamanov@itstep.org",
        "your_google_app_password"
        );
    var inbox = imapClient.GetFolder("Inbox");
    inbox.Open(FolderAccess.ReadWrite);

    //// read messages
    var ids = inbox.Search(SearchQuery.All);
    foreach (var id in ids)
    {
        Console.WriteLine($"{id} {inbox.GetMessage(id).TextBody}");
    }

    //inbox.SetFlags(new List<int> { 0, 3 }, MessageFlags.Deleted, true);
    //inbox.Expunge();
    //inbox.Close();
}
