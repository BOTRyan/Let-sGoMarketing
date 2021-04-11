using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class SendToGoogle : MonoBehaviour
{
    public GameManager manager;

    //email stuff required. Unsafe: use a burner email
    const string senderEmail = "fsu.lgm@gmail.com";
    //const string webhostURL = "http://lgm-emails.000webhostapp.com/emailer.php";

    const string messagePart1 = ", congrats on your win!\n\n" +
        "You finished the Let’s Go Marketing game first, so you win a free Ferris State Marketing shirt! All we need is for you to click the following link and enter your information into the form.\n\n" +
        "<a href=\"https://www.typeform.com/\">Score Your Free Merch Here</a>\n\n";
    const string messagePart2 = " for your career choice! Awesome pick!\n\n";
    const string messagePart3 = "Here is some more information related to this selection:\n\n" +
        "<a href=\"https://graphicdesign.ferris.edu/\">Ferris State Design Program Page</a>\n" +
        "<a href=\"https://www.ferris.edu/admissions/schedule_visit.htm\">Set up a Campus/Program Tour at Ferris State</a>\n\n" +
        "We appreciate you playing our game! Please let us know what you think and how we can make it better by completing our feedback survey.\n\n" +
        "<a href=\"https://ferrisdsgn.typeform.com/to/hIYzD9Jv\">Feedback Survey</a>";
    string compiledMessage;
    string careerInfo = "Salary\nDescription\n\n";

    string Name;
    string Email;
    string Field;
    string Career;
    string Color;
    string Duration;
    //tokens
    string TokenA, TokenG, TokenB, TokenM, TokenD, TokenP;
    //spaces
    string YTB, DYK, CP, BC, Normal;
    int Placement;

    [SerializeField]
    const string webhostURL = "https://lgm-emails.000webhostapp.com/emailer.php";
    readonly string postURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdOurHMy2joAjqGWQZaCpMzSxhaqo7eR9auIkD22Jlsea-qew/formResponse";

    void Start()//find GameManager so that the script can be attached literally anywhere and it doesn't matter (as long as the GameManager has all the data we need)
    {
        manager = FindObjectOfType<GameManager>();
    }

    void jobInfo(string career)
    {
        //fills out the careerInfo (salary + description)
        switch (career)//fill out
        {
            case "Advertising Account Manager":
                careerInfo = "Average Salary: $62,262/year\n" +
                    "Advertising Account Managers work for advertising agencies developing advertising strategies and campaigns for manufacturing, retailing, and service businesses. They work with advertising \"creatives\" like designers, " +
                    "copy writers, media production companies, and networks/magazines.\n\n";
                break;
            case "Brand/Product Manager":
                careerInfo = "Average Salary: $132,840/year\n" +
                    "Brand or Product Managers develop and execute the firm's product, place (distribution), price, and promotion strategies to maximize sales, profits, market share, and customer satisfaction. " + 
                    "Marketing Managers work with advertising and promotion agencies to promote the firm's or organization's products and services.\n\n";
                break;
            case "Sales Professional":
                careerInfo = "Average Salary: $62,080/year\n" +
                    "Sales representatives generally work for manufacturers, wholesalers, or business service firms, selling goods or services to businesses, government agencies, and other organizations. " +
                    "They contact customers, explain product features, and answer any questions that their customers may have. When working with retailers, they may help arrange promotional programs, store displays, and advertising.\n\n";
                break;
            case "Marketing Research Specialist":
                careerInfo = "Average Salary: $50,500/year\n" +
                    "The duties of a marketing research specialist include conducting market research to establish customer trends & habits and assisting with the analyses of marketing data, including campaign results, conversion rates, " +
                    "and online traffic in order to improve future marketing strategies and campaigns. They perform other duties when needed.\n\n";
                break;
            case "Marketing Director":
                careerInfo = "Average Salary: $115,000/year\n" +
                    "Marketing Directors evaluate and develop our marketing strategy and marketing plan. They plan, direct, and coordinate marketing efforts. They communicate the marketing plan and research demand for " +
                    "our products and services.\n\n";
                break;
            case "Sales Manager":
                careerInfo = "Average Salary: $74,750/year\n" +
                    "Sales managers lead a sales team by providing guidance, training, and mentorship, setting sales quotas and goals, creating sales plans, analyzing data, assinging sales territories, " +
                    "and building their team.\n\n";
                break;
            case "Freelance Writer":
                careerInfo = "Average Salary: $49,400/year\n" +
                    "A freelance writer's job responsibilities involve journal publishing, copy editing, proofreading, indexing, and even graphic designing. Freelance writers are involved in creating works on their own initiative, " +
                    "keeping the copyright of their works, and selling rights to publishers.\n\n";
                break;
            case "Healthcare Marketer":
                careerInfo = "Average Salary: $84,000/year\n" +
                    "Healthcare marketing professionals, also called marketing managers, directors, or coordinators, are responsible for developing and executing marketing plans for hospitals, nursing homes, " +
                    "outpatient care centers, and other medical facilities.\n\n";
                break;
            case "Graphic Media Technician":
                careerInfo = "Average Salary: $49,000/year\n" +
                    "Graphic Media Technicians help develop concepts for projects and prepare production materials for press, electronic, or multimedia publishing. You may work for publishing, communications, advertising, " +
                    "marketing, printing, or multimedia companies.\n\n";
                break;
            case "Graphic Media Technical Sales Representativ":
                careerInfo = "Average Salary: $49,000/year\n" +
                    "Graphic Media Technical Sales Representative responsibilities include: selling products and servies using solid arguments to prospective customers, performing cost-benefit analyses of existing and potential " +
                    "customers, maintaining positive business relationships to ensure future sales, and helping inform consumers of processes and related technologies.\n\n";
                break;
            case "Customer Service Project Manager":
                careerInfo = "Average Salary: $75,000/year\n" +
                    "Project managers are the people in charge of a specific project or projects within a company. As the project manager, your job is to plan, budget, oversee, and document all aspects of the specific project " +
                    "you are working on. Project managers might work by themselves or be in charge of a team to get the job done.\n\n";
                break;
            case "Business Data Analyst":
                careerInfo = "Average Salary: $69,252/year\n" +
                    "Business Data Analysts perform routine business analysis using various techniques, e.g. statistical analysis, explanatory and predictive modeling, and data mining. They research best practices and " +
                    "support developing the solutions and recommendations for the current business operations.\n\n";
                break;
            case "Market Research Analyst":
                careerInfo = "Average Salary: $58,000/year\n" +
                    "Market Research Analysts perform research and gather data to help a company market its products or services. They gather data on consumer demographics, preferences, needs, and buying habits.\n\n";
                break;
            case "System Architect":
                careerInfo = "Average Salary: $105,000/year\n" +
                    "System Architects devise, build, and maintain networking and computer systems. Communication is a key skill for system architects; job duties for this position include ensuring that client and company " +
                    "needs are met, offering technical support, and creating instillation instructions for users.\n\n";
                break;
            case "Creative Director":
                careerInfo = "Average Salary: $132,770/year\n" +
                    "A Creative Director is in charge of the creative department at advertising and marketing companies. Their duties include planning company advertisements, monitoring brand campaigns, revising presentations, " +
                    "and shaping brand standards.\n\n";
                break;
            case "Research Director":
                careerInfo = "Average Salary: $117,000/year\n" +
                    "Research Directors manage the research budget and the allocation of funds. They design methods for evaluating the effectiveness of research programs and oversee the operation of laboratories and research " +
                    "sites, ensuring compliance with institutional and governmental regulations.\n\n";
                break;
            case "Media Planner":
                careerInfo = "Average Salary: $54,000/year\n" +
                    "Media Planners produce action plans for advertising campaigns from pre-defined marketing objectives. They select media platforms that best suit the brand of product that will be advertised. Typical " +
                    "responsibilities of the job include producing financial and media plans & forecasts.\n\n";
                break;
            case "User Experience Designer":
                careerInfo = "Average Salary: $90,700/year\n" +
                    "UX Designer responsibilities include: conducting user research and testing, developing wireframes and task flows based on user needs, and collaborating with designers and developers to create " +
                    "intuitive, user-friendly software.\n\n";
                break;
            case "User Interface Designer":
                careerInfo = "Average Salary: $80,500/year\n" +
                    "User Interface (UI) Designers work closely with User Experience (UX) Designers and other design specialists. Their job is to make sure that every page and every step a user will experience in their " +
                    "interaction with the finished product will conform to the overall vision created by UX Designers.\n\n";
                break;
            case "Content Strategist":
                careerInfo = "Average Salary: $72,500/year\n" +
                    "Creative professionals in this role oversee content requirements and create content strategy deliverables across a project life cycle. The Content Strategist is often in charge of creating and maintaining " +
                    "editorial calendars, style guides, taxonomies, metadata frameworks, and content migration plans.\n\n";
                break;
            case "Corporate Communications Manager":
                careerInfo = "Average Salary: $70,401/year\n" +
                    "Communication Managers are in charge of overseeing all internal and external communications for a company, ensuring its message is consistent and engaging. Also known as a Communications Director, their " +
                    "main duties include preparing detailed media reports, press releases, and marketing materials.\n\n";
                break;
            case "Public Relations Director":
                careerInfo = "Average Salary: $82,800/year\n" +
                    "Public Relations Directors develop and execute strategies that are intended to create and uphold a positive public image for clients. By working and forming relationships with various members of the " +
                    "media, government, and public, directors generate new business oppportunities.\n\n";
                break;
        }//switch
    }//jobInfo()



    IEnumerator SendMailRequestToServer(string toName, string toEmail, string toCareer, int toPlacement)
    {
        jobInfo(toCareer);
        if(toPlacement == 0)
        {
            compiledMessage = "Hey " + toName + messagePart1 + "You chose " + toCareer + messagePart2 + careerInfo + messagePart3;
        }
        else
        {
            compiledMessage = "Hey " + toName + ",\n\nYou chose " + toCareer + messagePart2 + careerInfo + messagePart3;
        }

        // Setup form responses
        /*WWWForm form = new WWWForm();
        form.AddField("name", "It's me!");
        form.AddField("fromEmail", senderEmail);
        form.AddField("toEmail", toEmail);
        form.AddField("message", compiledMessage);

        // Submit form to our server, then wait
        UnityWebRequest www = UnityWebRequest.Post(webhostURL, form);
        Debug.Log("Email sent to " + toEmail);

        yield return www.SendWebRequest();*/

        // Print results
        /*if (www.error == null)
        {
            Debug.Log("WWW Success!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }*/
        //if (www.isNetworkError || www.isHttpError) Debug.Log("error: " + www.error);
        //else Debug.Log("Sent player email");


        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        form.Add(new MultipartFormDataSection("name", "It's me!"));
        form.Add(new MultipartFormDataSection("fromEmail", senderEmail));
        form.Add(new MultipartFormDataSection("toEmail", toEmail));
        form.Add(new MultipartFormDataSection("message", compiledMessage));

        UnityWebRequest www = UnityWebRequest.Post(webhostURL, form);

        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Error");
        }
        else
        {
            Debug.Log("Sent email to " + toEmail);
        }
    }



    IEnumerator Post(string nameIn, string emailIn, string fieldIn, string careerIn, string colorIn, string tokenAIn, string tokenGIn, string tokenBIn, string tokenMIn, string tokenDIn, string tokenPIn, string ytbIn, string dykIn, string cpIn, string bcIn, string normalIn)
    {
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        //look for the sections in the URL that require input. Tutorial to find that value here: https://www.youtube.com/watch?v=z9b5aRfrz7M&ab_channel=LuzanBaral
        form.Add(new MultipartFormDataSection("entry.1774318415", nameIn));
        form.Add(new MultipartFormDataSection("entry.447813241", emailIn));
        form.Add(new MultipartFormDataSection("entry.1774298051", fieldIn));
        form.Add(new MultipartFormDataSection("entry.1309134014", careerIn));
        form.Add(new MultipartFormDataSection("entry.906285824", colorIn));

        //tokens
        form.Add(new MultipartFormDataSection("entry.297539896", tokenAIn));
        form.Add(new MultipartFormDataSection("entry.285011331", tokenGIn));
        form.Add(new MultipartFormDataSection("entry.1840331461", tokenBIn));
        form.Add(new MultipartFormDataSection("entry.621689233", tokenMIn));
        form.Add(new MultipartFormDataSection("entry.1409755334", tokenDIn));
        form.Add(new MultipartFormDataSection("entry.1815462484", tokenPIn));

        //spaces
        form.Add(new MultipartFormDataSection("entry.122754949", ytbIn));
        form.Add(new MultipartFormDataSection("entry.855798970", dykIn));
        form.Add(new MultipartFormDataSection("entry.1505258852", cpIn));
        form.Add(new MultipartFormDataSection("entry.150968286", bcIn));
        form.Add(new MultipartFormDataSection("entry.483335758", normalIn));

        UnityWebRequest www = UnityWebRequest.Post(postURL, form);

        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) Debug.Log("error: " + www.error);
        else Debug.Log("Sent player data");
    }

    IEnumerator PostGameData(string durationIn)
    {
        //wait two seconds so the organization works in the Google Sheet
        yield return new WaitForSeconds(2);

        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        form.Add(new MultipartFormDataSection("entry.806798460", durationIn));

        UnityWebRequest www = UnityWebRequest.Post(postURL, form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) Debug.Log("error: " + www.error);
        else Debug.Log("Sent game data");
    }

    public void SendData()
    {
        manager = FindObjectOfType<GameManager>();
        Debug.Log("SendData() called");
        //iterate through the list of players for their info
        for (int i = 0; i < manager.currPlayers; ++i)
        {
            Debug.Log("Getting Player " + (i + 1));
            Name = manager.players[i].GetComponent<PlayerInfo>().playerName;
            Email = manager.players[i].GetComponent<PlayerInfo>().email;
            Field = manager.players[i].GetComponent<PlayerInfo>().fieldChoice;
            Color = manager.players[i].GetComponent<PlayerInfo>().avatar.name;
            Color = Color.Substring(0, Color.IndexOf("Sit"));
            Placement = manager.players[i].GetComponent<PlayerInfo>().place;

            Career = manager.players[i].GetComponent<PlayerInfo>().careerChoice.name;
            switch(Career)
            {
                case "jc-blue1":
                    Career = "Advertising Account Manager";
                    break;
                case "jc-blue2":
                    Career = "Brand/Product Manager";
                    break;
                case "jc-blue3":
                    Career = "Sales Professional";
                    break;
                case "jc-blue4":
                    Career = "Marketing Research Specialist";
                    break;
                case "jc-blue5":
                    Career = "Marketing Director";
                    break;
                case "jc-blue6":
                    Career = "Sales Manager";
                    break;
                case "jc-blue7":
                    Career = "Freelance Writer";
                    break;
                case "jc-blue8":
                    Career = "Healthcare Marketer";
                    break;
                case "jc-green1":
                    Career = "Graphic Media Technician";
                    break;
                case "jc-green2":
                    Career = "Graphic Media Technical Sales Representativ";
                    break;
                case "jc-green3":
                    Career = "Customer Service Project Manager";
                    break;
                case "jc-pink1":
                    Career = "Business Data Analyst";
                    break;
                case "jc-pink2":
                    Career = "Market Research Analyst";
                    break;
                case "jc-pink3":
                    Career = "System Architect";
                    break;
                case "jc-purple1":
                    Career = "Creative Director";
                    break;
                case "jc-purple2":
                    Career = "Research Director";
                    break;
                case "jc-purple3":
                    Career = "Media Planner";
                    break;
                case "jc-red2":
                    Career = "User Experience Designer";
                    break;
                case "jc-red3":
                    Career = "User Interface Designer";
                    break;
                case "jc-yellow1":
                    Career = "Content Strategist";
                    break;
                case "jc-yellow2":
                    Career = "Corporate Communications Manager";
                    break;
                case "jc-yellow4":
                    Career = "Public Relations Director";
                    break;
            }//switch

            
            //tokens
            TokenA = manager.players[i].GetComponent<PlayerInfo>().tokens[5].ToString();
            TokenG = manager.players[i].GetComponent<PlayerInfo>().tokens[1].ToString();
            TokenB = manager.players[i].GetComponent<PlayerInfo>().tokens[3].ToString();
            TokenM = manager.players[i].GetComponent<PlayerInfo>().tokens[0].ToString();
            TokenD = manager.players[i].GetComponent<PlayerInfo>().tokens[2].ToString();
            TokenP = manager.players[i].GetComponent<PlayerInfo>().tokens[4].ToString();

            //spaces
            YTB = manager.players[i].GetComponent<PlayerInfo>().spaces[0].ToString();
            DYK = manager.players[i].GetComponent<PlayerInfo>().spaces[1].ToString();
            CP = manager.players[i].GetComponent<PlayerInfo>().spaces[2].ToString();
            BC = manager.players[i].GetComponent<PlayerInfo>().spaces[3].ToString();
            Normal = manager.players[i].GetComponent<PlayerInfo>().spaces[4].ToString();

            Debug.Log("Starting Coroutine");
            StartCoroutine(Post(Name, Email, Field, Career, Color, TokenA, TokenG, TokenB, TokenM, TokenD, TokenP, YTB, DYK, CP, BC, Normal));
            StartCoroutine(SendMailRequestToServer(Name, Email, Career, Placement));
        }

        //send Duration
        Duration = ((manager.gameTime)/60f).ToString();
        StartCoroutine(PostGameData(Duration));

        StartCoroutine(SendMailRequestToServer());
    }//Send()






    // Method 2: Server request
    static IEnumerator SendMailRequestToServer()
    {
        // Setup form responses
        WWWForm form = new WWWForm();
        form.AddField("name", "It's me!");
        form.AddField("fromEmail", senderEmail);
        form.AddField("toEmail", "laij3@ferris.edu");
        form.AddField("message", "Test copy/paste");

        // Submit form to our server, then wait
        WWW www = new WWW(webhostURL, form);
        Debug.Log("Email sent! (Copy/paste)");

        yield return www;

        // Print results
        if (www.error == null)
        {
            Debug.Log("WWW Success!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
