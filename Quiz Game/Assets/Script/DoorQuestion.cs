using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorQuestion : MonoBehaviour
{
    public GameManager GM;

    private enum OpenDirection { x, y, z}
    private OpenDirection direction = OpenDirection.y;
    private float openDistance = 3f;
    private float openSpeed = 2.0f;
    public Transform doorBody;
    private bool open = false;
    private bool istriggered = false;
    Vector3 defaultDoorPosition;
    private float questionNumberEasy;
    private float questionNumberNormal;
    private float questionNumberHard;
    private bool answered=false;
    public Text question;
    public GameObject answers;
    public PlayerControl pc;
    public Button[] buttons;
    public int correct;
    public int option;

    private void Start()
    {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        questionNumberEasy = -1;
        questionNumberNormal = -1;
        questionNumberHard = -1;
        answered = false;
        if (doorBody)
        {
            defaultDoorPosition = doorBody.localPosition;
        }
    }

    private void Update()
    {
        if (!doorBody)
            return;
        if (direction == OpenDirection.x)
        {
            doorBody.localPosition = new Vector3(Mathf.Lerp(doorBody.localPosition.x, defaultDoorPosition.x + (open ? openDistance : 0),
                Time.deltaTime * openSpeed), doorBody.localPosition.y, doorBody.localPosition.z);
        }
        else if (direction == OpenDirection.y)
        {
            doorBody.localPosition = new Vector3(doorBody.localPosition.x, Mathf.Lerp(doorBody.localPosition.y,
                defaultDoorPosition.y + (open ? openDistance : 0), Time.deltaTime * openSpeed), doorBody.localPosition.z);
        }
        else if (direction == OpenDirection.z)
        {
            doorBody.localPosition = new Vector3(doorBody.localPosition.x, doorBody.localPosition.y, Mathf.Lerp(doorBody.localPosition.z,
                defaultDoorPosition.z + (open ? openDistance : 0), Time.deltaTime * openSpeed));
        }
    }

    private void questionRandom()
    {
        if (istriggered == true && PlayerPrefs.GetInt("CheckDifficulty", 0) == 0)
        {
            questionNumberEasy = (Mathf.Floor(Random.Range(0f, 20f)));
            switch (questionNumberEasy)
            {
                case 19:
                    question.text = "What is the full name of the UNSC?";
                    //United Nations Space Command, United Nations Security Council**, United Nations Space Council, United Nations Security Command
                    buttons[0].GetComponentInChildren<Text>().text = "United Nations Space Command";
                    buttons[1].GetComponentInChildren<Text>().text = "United Nations Security Council"; //correct
                    buttons[2].GetComponentInChildren<Text>().text = "United Nations Space Council";
                    buttons[3].GetComponentInChildren<Text>().text = "United Nations Security Command";
                    correct = 1;
                    break;
                case 18:
                    question.text = "Which of the following is not a province of America?";
                    //Nevada, Pennsylvania, Virginia, Quebec**
                    buttons[0].GetComponentInChildren<Text>().text = "Nevada";
                    buttons[1].GetComponentInChildren<Text>().text = "Pennsylvania";
                    buttons[2].GetComponentInChildren<Text>().text = "Virginia";
                    buttons[3].GetComponentInChildren<Text>().text = "Quebec"; //correct
                    correct = 3;
                    break;
                case 17:
                    question.text = "What is the Galaxy in which Earth resides in called?";
                    //The Galactic Federation, Guardians Of The Galaxy, The Big Bang, The Milky Way**
                    buttons[0].GetComponentInChildren<Text>().text = "The Galactic Federation";
                    buttons[1].GetComponentInChildren<Text>().text = "Guardians Of The Galaxy";
                    buttons[2].GetComponentInChildren<Text>().text = "The Big Bang";
                    buttons[3].GetComponentInChildren<Text>().text = "The Milky Way"; //correct
                    correct = 3;
                    break;
                case 16:
                    question.text = "Which of the following is not grown from a tree?";
                    //Lime, Banana, Lemon, Watermelon**
                    buttons[0].GetComponentInChildren<Text>().text = "Lime";
                    buttons[1].GetComponentInChildren<Text>().text = "Banana";
                    buttons[2].GetComponentInChildren<Text>().text = "Lemon";
                    buttons[3].GetComponentInChildren<Text>().text = "Watermelon"; //correct
                    correct = 3;
                    break;
                case 15:
                    question.text = "What is D&D called in full?";
                    //Dungeon & Dragons**, Dawn & Drawing, Drink & Driving, Dove & Drove
                    buttons[0].GetComponentInChildren<Text>().text = "Dungeon & Dragons"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "Dawn & Drawing";
                    buttons[2].GetComponentInChildren<Text>().text = "Drink & Driving";
                    buttons[3].GetComponentInChildren<Text>().text = "Dove & Drove";
                    correct = 0;
                    break;
                case 14:
                    question.text = "What do plants need not to survive?";
                    //Food, Water, Sunlight, Leaves**
                    buttons[0].GetComponentInChildren<Text>().text = "Food";
                    buttons[1].GetComponentInChildren<Text>().text = "Water";
                    buttons[2].GetComponentInChildren<Text>().text = "Sunlight";
                    buttons[3].GetComponentInChildren<Text>().text = "Leaves"; //correct
                    correct = 3;
                    break;
                case 13:
                    question.text = "What do you call a land surrounded by water?";
                    //Land, Island**, Sea, Floating Castle
                    buttons[0].GetComponentInChildren<Text>().text = "Land";
                    buttons[1].GetComponentInChildren<Text>().text = "Island"; //correct
                    buttons[2].GetComponentInChildren<Text>().text = "Sea";
                    buttons[3].GetComponentInChildren<Text>().text = "Floating Castle";
                    correct = 1;
                    break;
                case 12:
                    question.text = "When is Singapore's National Day?";
                    //Monday, 8 August/ Monday, 7 August/ Monday, 10 August/ Monday, 9 August**
                    buttons[0].GetComponentInChildren<Text>().text = "8th August"; 
                    buttons[1].GetComponentInChildren<Text>().text = "7th August";
                    buttons[2].GetComponentInChildren<Text>().text = "10th August";
                    buttons[3].GetComponentInChildren<Text>().text = "9th August"; //correct
                    correct = 3;
                    break;
                case 11:
                    question.text = "What planet do we live on?";
                    //Earth**, Singapore, Mars, Mercury
                    buttons[0].GetComponentInChildren<Text>().text = "Earth"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "Singapore";
                    buttons[2].GetComponentInChildren<Text>().text = "Mars";
                    buttons[3].GetComponentInChildren<Text>().text = "Mercury";
                    correct = 0;
                    break;
                case 10:
                    question.text = "Where do birds usually nest?";
                    //Trees, Bushes, Roof, All of the above**
                    buttons[0].GetComponentInChildren<Text>().text = "Trees";
                    buttons[1].GetComponentInChildren<Text>().text = "Bushes";
                    buttons[2].GetComponentInChildren<Text>().text = "Roof";
                    buttons[3].GetComponentInChildren<Text>().text = "All of the above"; //correct
                    correct = 3;
                    break;
                case 9:
                    question.text = "What are the 3 states of matter?";
                    //Solid, Liquid, Air/ Heat, Cool, Warm/ Ice, Water, Oxygen/ Solid, Liquid, Gas**
                    buttons[0].GetComponentInChildren<Text>().text = "Solid, Liquid, Air";
                    buttons[1].GetComponentInChildren<Text>().text = "Heat, Cool, Warm";
                    buttons[2].GetComponentInChildren<Text>().text = "Ice, Water, Oxygen";
                    buttons[3].GetComponentInChildren<Text>().text = "Solid, Liquid, Gas"; //correct
                    correct = 3;
                    break;
                case 8:
                    question.text = "What is air mostly composed of?";
                    //Nitrogen**, Oxygen, Carbon Dioxide, argon
                    buttons[0].GetComponentInChildren<Text>().text = "Nitrogen"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "Oxygen";
                    buttons[2].GetComponentInChildren<Text>().text = "Carbon Dioxide";
                    buttons[3].GetComponentInChildren<Text>().text = "Argon";
                    correct = 0;
                    break;
                case 7:
                    question.text = "What do humans breathe?";
                    //Carbon Dioxide, Oxygen**, Air, Gas
                    buttons[0].GetComponentInChildren<Text>().text = "Carbon Dioxide";
                    buttons[1].GetComponentInChildren<Text>().text = "Oxygen"; //correct
                    buttons[2].GetComponentInChildren<Text>().text = "Air";
                    buttons[3].GetComponentInChildren<Text>().text = "Gas";
                    correct = 1;
                    break;
                case 6:
                    question.text = "What do you call the leftover value of the division of an equation?";
                    //Reminder, Remember, Remainder**, What is math?
                    buttons[0].GetComponentInChildren<Text>().text = "Reminder";
                    buttons[1].GetComponentInChildren<Text>().text = "Remember";
                    buttons[2].GetComponentInChildren<Text>().text = "Remainder"; //correct
                    buttons[3].GetComponentInChildren<Text>().text = "What is math?";
                    correct = 2;
                    break;
                case 5:
                    question.text = "How many stars are there on the Singapore flag?";
                    //4 stars, 7 stars, 5 stars**, What are stars
                    buttons[0].GetComponentInChildren<Text>().text = "4 stars";
                    buttons[1].GetComponentInChildren<Text>().text = "7 stars";
                    buttons[2].GetComponentInChildren<Text>().text = "5 stars"; //correct
                    buttons[3].GetComponentInChildren<Text>().text = "What are stars";
                    correct = 2;
                    break;
                case 4:
                    question.text = "What are the three primary colors?";
                    //Red, Yellow, Green/ Green, White, Black/ Red, Blue, Yellow**/ Black, White, Grey
                    buttons[0].GetComponentInChildren<Text>().text = "Red, Yellow, Green";
                    buttons[1].GetComponentInChildren<Text>().text = "Green, White, Black";
                    buttons[2].GetComponentInChildren<Text>().text = "Red, Blue, Yellow"; //correct
                    buttons[3].GetComponentInChildren<Text>().text = "Black, White, Grey";
                    correct = 2;
                    break;
                case 3:
                    question.text = "Who is Singapore’s current Prime Minister?";
                    //Lee Kuan Yew, Lee Hsien Loong**, Lee Hsien Yang, The current one
                    buttons[0].GetComponentInChildren<Text>().text = "Lee Kuan Yew";
                    buttons[1].GetComponentInChildren<Text>().text = "Lee Hsien Loong"; //correct
                    buttons[2].GetComponentInChildren<Text>().text = "Lee Hsien Yang";
                    buttons[3].GetComponentInChildren<Text>().text = "The current one";
                    correct = 1;
                    break;
                case 2:
                    question.text = "What is Singapore’s National Anthem called?";
                    //Singapura, Onward Singapore**, Singapura Forward, Onward Singapura
                    buttons[0].GetComponentInChildren<Text>().text = "Singapura";
                    buttons[1].GetComponentInChildren<Text>().text = "Onward Singapore"; //correct
                    buttons[2].GetComponentInChildren<Text>().text = "Singapura Forward";
                    buttons[3].GetComponentInChildren<Text>().text = "Onward Singapura";
                    correct = 1;
                    break;
                case 1:
                    question.text = "What is 1+1??";
                    //Math no good, 2, 3**, 4
                    buttons[0].GetComponentInChildren<Text>().text = "Math no good";
                    buttons[1].GetComponentInChildren<Text>().text = "2"; //correct
                    buttons[2].GetComponentInChildren<Text>().text = "3";
                    buttons[3].GetComponentInChildren<Text>().text = "4";
                    correct = 1;
                    break;
                case 0:
                    question.text = "What is the throat called in scientific terms?";
                    //Neck, Windpipe, Oesophagus**, Collarbone
                    buttons[0].GetComponentInChildren<Text>().text = "Neck";
                    buttons[1].GetComponentInChildren<Text>().text = "Windpipe";
                    buttons[2].GetComponentInChildren<Text>().text = "Oesophagus"; //correct
                    buttons[3].GetComponentInChildren<Text>().text = "Collarbone";
                    correct = 2;
                    break;
            }
        }
        else if (istriggered == true && PlayerPrefs.GetInt("CheckDifficulty", 1) == 1)
        {
            questionNumberNormal = (Mathf.Floor(Random.Range(0f, 20f)));
            switch (questionNumberNormal)
            {
                case 19:
                    question.text = "What does one have but can never obtain?";
                    //Faith**, Books, Desire, Looks
                    buttons[0].GetComponentInChildren<Text>().text = "Faith"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "Books";
                    buttons[2].GetComponentInChildren<Text>().text = "Desire";
                    buttons[3].GetComponentInChildren<Text>().text = "Looks";
                    correct = 0;
                    break;
                case 18:
                    question.text = "Which of the following is not true about humans?";
                    //Having more than 2 lungs, Having more than 1 heart. We hibernate, All of the Above**
                    buttons[0].GetComponentInChildren<Text>().text = "Having more than 2 lungs";
                    buttons[1].GetComponentInChildren<Text>().text = "Having more than 1 heart";
                    buttons[2].GetComponentInChildren<Text>().text = "We hibernate";
                    buttons[3].GetComponentInChildren<Text>().text = "All of the Above"; //correct
                    correct = 3;
                    break;
                case 17:
                    question.text = "What do all nations have in common?";
                    //A leader, People**, Resources, A God
                    buttons[0].GetComponentInChildren<Text>().text = "A leader";
                    buttons[1].GetComponentInChildren<Text>().text = "People"; //correct
                    buttons[2].GetComponentInChildren<Text>().text = "Resources";
                    buttons[3].GetComponentInChildren<Text>().text = "A God";
                    correct = 1;
                    break;
                case 16:
                    question.text = "What do all Singaporeans have in common?";
                    //SingPass**, National Service, Nerds, Freedom!
                    buttons[0].GetComponentInChildren<Text>().text = "SingPass"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "National Service";
                    buttons[2].GetComponentInChildren<Text>().text = "Nerds";
                    buttons[3].GetComponentInChildren<Text>().text = "Freedom!";
                    correct = 0;
                    break;
                case 15:
                    question.text = "Which of the following items do most people have?";
                    //Coins, Phones, Cards, Clothes**
                    buttons[0].GetComponentInChildren<Text>().text = "Coins";
                    buttons[1].GetComponentInChildren<Text>().text = "Phones";
                    buttons[2].GetComponentInChildren<Text>().text = "Cards";
                    buttons[3].GetComponentInChildren<Text>().text = "Clothes"; //correct
                    correct = 3;
                    break;
                case 14:
                    question.text = "Which of the following do human’s body have?";
                    //Food, Light, Cells**, Electrum
                    buttons[0].GetComponentInChildren<Text>().text = "Food";
                    buttons[1].GetComponentInChildren<Text>().text = "Light";
                    buttons[2].GetComponentInChildren<Text>().text = "Cells";//correct
                    buttons[3].GetComponentInChildren<Text>().text = "Electrum";
                    correct = 2;
                    break;
                case 13:
                    question.text = "What is the same characteristic between Solid, Liquid and Gas?";
                    //They are all a Matter**, They have the same component, There is nothing similar, They exist
                    buttons[0].GetComponentInChildren<Text>().text = "They are all a Matter";//correct
                    buttons[1].GetComponentInChildren<Text>().text = "They have the same component";
                    buttons[2].GetComponentInChildren<Text>().text = "There is nothing similar";
                    buttons[3].GetComponentInChildren<Text>().text = "They exist";
                    correct = 0;
                    break;
                case 12:
                    question.text = "What do you call someone who knows all?";
                    //A sage, A Man, A wiseman, Someone who ask questions**
                    buttons[0].GetComponentInChildren<Text>().text = "A sage";
                    buttons[1].GetComponentInChildren<Text>().text = "A Man";
                    buttons[2].GetComponentInChildren<Text>().text = "A wiseman";
                    buttons[3].GetComponentInChildren<Text>().text = "Someone who ask questions"; //correct
                    correct = 3;
                    break;
                case 11:
                    question.text = "What do you call someone who wields a sword?";
                    //Swordsmen/swordswomen, Sword Master, Soldier, A man with a sword
                    buttons[0].GetComponentInChildren<Text>().text = "wordsmen/swordswomen";
                    buttons[1].GetComponentInChildren<Text>().text = "Sword Master";
                    buttons[2].GetComponentInChildren<Text>().text = "Soldier";
                    buttons[3].GetComponentInChildren<Text>().text = "A man with a sword"; //correct
                    correct = 3;
                    break;
                case 10:
                    question.text = "What do sailors do best?";
                    //Playing around, Sailing the seas**, Fighting, Singing sea shanties
                    buttons[0].GetComponentInChildren<Text>().text = "Playing around";
                    buttons[1].GetComponentInChildren<Text>().text = "Sailing the seas"; //correct
                    buttons[2].GetComponentInChildren<Text>().text = "Fighting";
                    buttons[3].GetComponentInChildren<Text>().text = "Singing sea shanties";
                    correct = 1;
                    break;
                case 9:
                    question.text = "Which province is part of Europe?";
                    //Singapore, Texas, Provence**, Japan
                    buttons[0].GetComponentInChildren<Text>().text = "Singapore";
                    buttons[1].GetComponentInChildren<Text>().text = "Texas";
                    buttons[2].GetComponentInChildren<Text>().text = "Provence"; //correct
                    buttons[3].GetComponentInChildren<Text>().text = "Japan";
                    correct = 2;
                    break;
                case 8:
                    question.text = "When did the Great Emu War start?";
                    //2 November 1932**, 5 November 1932, 16 November 1932, was there really an emu war?
                    buttons[0].GetComponentInChildren<Text>().text = "2 November 1932";//correct
                    buttons[1].GetComponentInChildren<Text>().text = "5 November 1932";
                    buttons[2].GetComponentInChildren<Text>().text = "16 November 1932";
                    buttons[3].GetComponentInChildren<Text>().text = "was there really an emu war?";
                    correct = 1;
                    break;
                case 7:
                    question.text = "Which of the animals hibernates?";
                    //Wolf, Seagulls, Skunks**, All of the above
                    buttons[0].GetComponentInChildren<Text>().text = "Wolf";
                    buttons[1].GetComponentInChildren<Text>().text = "Seagulls";
                    buttons[2].GetComponentInChildren<Text>().text = "Skunks"; //correct
                    buttons[3].GetComponentInChildren<Text>().text = "All of the above";
                    correct = 2;
                    break;
                case 6:
                    question.text = "Which of the following applications is used for tracing people’s locations?";
                    //Trace together**, Google Map, Translator, All of the above
                    buttons[0].GetComponentInChildren<Text>().text = "Trace together";//correct
                    buttons[1].GetComponentInChildren<Text>().text = "Google Map";
                    buttons[2].GetComponentInChildren<Text>().text = "Translator";
                    buttons[3].GetComponentInChildren<Text>().text = "All of the above";
                    correct = 0;
                    break;
                case 5:
                    question.text = "Which of the following applications is used for meetings?";
                    //Zoom, Discord, Mircosoft Teams, All of the above**
                    buttons[0].GetComponentInChildren<Text>().text = "Zoom";
                    buttons[1].GetComponentInChildren<Text>().text = "Discord";
                    buttons[2].GetComponentInChildren<Text>().text = "Microsoft Teams";
                    buttons[3].GetComponentInChildren<Text>().text = "All of the above"; //correct
                    correct = 2;
                    break;
                case 4:
                    question.text = "Which type of flowers exist in the world?";
                    //Fire, Angelica, Guklulla, Cypripedium Calceolus**
                    buttons[0].GetComponentInChildren<Text>().text = "Fire";
                    buttons[1].GetComponentInChildren<Text>().text = "Angelica";
                    buttons[2].GetComponentInChildren<Text>().text = "Guklulla";
                    buttons[3].GetComponentInChildren<Text>().text = "Cypripedium Calceolus"; //correct
                    correct = 3;
                    break;
                case 3:
                    question.text = "What is Singapore’s national flower called?";
                    //Chrysanthemum, Plum Blossom, Cornus Canadensis, Hybrid Orchid**
                    buttons[0].GetComponentInChildren<Text>().text = "Chrysanthemum";
                    buttons[1].GetComponentInChildren<Text>().text = "Plum Blossom";
                    buttons[2].GetComponentInChildren<Text>().text = "Cornus Canadensis";
                    buttons[3].GetComponentInChildren<Text>().text = "Hybrid Orchid"; //correct
                    correct = 3;
                    break;
                case 2:
                    question.text = "What is the name of the greatest game in 2001?";
                    //Halo: Combat Evolve**, Final Fantasy 1, Baldur’s Gate: Dark Alliance, Runescape
                    buttons[0].GetComponentInChildren<Text>().text = "Halo: Combat Evolve"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "Final Fantasy 1";
                    buttons[2].GetComponentInChildren<Text>().text = "Baldur’s Gate: Dark Alliance";
                    buttons[3].GetComponentInChildren<Text>().text = "Runescape";
                    correct = 0;
                    break;
                case 1:
                    question.text = "What breathes, consumes, and grows, but was and never will be alive?";
                    //Stomach, Fire**, Air, Earth
                    buttons[0].GetComponentInChildren<Text>().text = "Stomach";
                    buttons[1].GetComponentInChildren<Text>().text = "Fire"; //correct
                    buttons[2].GetComponentInChildren<Text>().text = "Air";
                    buttons[3].GetComponentInChildren<Text>().text = "Earth";
                    correct = 1;
                    break;
                case 0:
                    question.text = "Which of the following plants is not a vegetable?";
                    //Lettuce, Green Beans, Beets, Oranges**
                    buttons[0].GetComponentInChildren<Text>().text = "Lettuce";
                    buttons[1].GetComponentInChildren<Text>().text = "Green Beans";
                    buttons[2].GetComponentInChildren<Text>().text = "Beets";
                    buttons[3].GetComponentInChildren<Text>().text = "Oranges"; //correct
                    correct = 3;
                    break;
            }
        }
        else if (istriggered == true && PlayerPrefs.GetInt("CheckDifficulty", 2) == 2)
        {
            questionNumberHard = (Mathf.Floor(Random.Range(0f, 20f)));
            switch (questionNumberHard)
            {
                case 19:
                    question.text = "Which company made halo?";
                    //343 Industries, Bungie**, nintendo, Microsoft
                    buttons[0].GetComponentInChildren<Text>().text = "343 Industries";
                    buttons[1].GetComponentInChildren<Text>().text = "Bungie"; //correct
                    buttons[2].GetComponentInChildren<Text>().text = "Nintendo";
                    buttons[3].GetComponentInChildren<Text>().text = "Microsoft";
                    correct = 1;
                    break;
                case 18:
                    question.text = "How many halo game is there?";
                    //2, 6, 8, 13**
                    buttons[0].GetComponentInChildren<Text>().text = "2";
                    buttons[1].GetComponentInChildren<Text>().text = "6";
                    buttons[2].GetComponentInChildren<Text>().text = "8";
                    buttons[3].GetComponentInChildren<Text>().text = "12"; //correct
                    correct = 3;
                    break;
                case 17:
                    question.text = "What is not true about matter?";
                    //Matter can be destroyed**, Matters can be converted, Matters have 3 states, Matter can change
                    buttons[0].GetComponentInChildren<Text>().text = "Matter can be destroyed"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "Matters can be converted";
                    buttons[2].GetComponentInChildren<Text>().text = "Matters have 3 states";
                    buttons[3].GetComponentInChildren<Text>().text = "Matter can change";
                    correct = 0;
                    break;
                case 16:
                    question.text = "Which of the following is true about matter?";
                    //Matter has mass**, Matter is not made up of atoms, Matter only have a liquid state, Matter can be destroyed
                    buttons[0].GetComponentInChildren<Text>().text = "Matter has mass"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "Matter is not made up of atoms";
                    buttons[2].GetComponentInChildren<Text>().text = "Matter only have a liquid state";
                    buttons[3].GetComponentInChildren<Text>().text = "Matter can be destroyed";
                    correct = 0;
                    break;
                case 15:
                    question.text = "During WWII, when did america send aid to britain?";
                    //March 1941**, March 1932, May 1942, December 1941
                    buttons[0].GetComponentInChildren<Text>().text = "March 1941"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "March 1932";
                    buttons[2].GetComponentInChildren<Text>().text = "May 1942";
                    buttons[3].GetComponentInChildren<Text>().text = "December 1941";
                    correct = 0;
                    break;
                case 14:
                    question.text = "When was the treaty of versailles?";
                    //June 12 1918, June 28, 1919**, July 29 1915, July 18, 1919
                    buttons[0].GetComponentInChildren<Text>().text = "June 12, 1918";
                    buttons[1].GetComponentInChildren<Text>().text = "June 28, 1919";//correct
                    buttons[2].GetComponentInChildren<Text>().text = "July 29, 1915";
                    buttons[3].GetComponentInChildren<Text>().text = "July 18, 1919";
                    correct = 1;
                    break;
                case 13:
                    question.text = "What is blitzkrieg?";
                    //Swift victory**, Continuous battle, Aerial battle, wait and see
                    buttons[0].GetComponentInChildren<Text>().text = "Swift victory"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "Continuous battle";
                    buttons[2].GetComponentInChildren<Text>().text = "Aerial battle";
                    buttons[3].GetComponentInChildren<Text>().text = "wait and see";
                    correct = 0;
                    break;
                case 12:
                    question.text = "How did Hitler die?";
                    //Killed in Action, Suicide**, Hanged, sentence to death.
                    buttons[0].GetComponentInChildren<Text>().text = "Killed in Action";
                    buttons[1].GetComponentInChildren<Text>().text = "Suicide"; //correct
                    buttons[2].GetComponentInChildren<Text>().text = "Hanged";
                    buttons[3].GetComponentInChildren<Text>().text = "sentence to death";
                    correct = 1;
                    break;
                case 11:
                    question.text = "When did Germany attack Russia?";
                    //12 June 1942, 28 July 1941, 12 June 1941, 22 June 1941**
                    buttons[0].GetComponentInChildren<Text>().text = "12 June 1942";
                    buttons[1].GetComponentInChildren<Text>().text = "28 July 1941";
                    buttons[2].GetComponentInChildren<Text>().text = "12 June 1941";
                    buttons[3].GetComponentInChildren<Text>().text = "22 June 1941"; //correct
                    correct = 3;
                    break;
                case 10:
                    question.text = "During World War II, how did Germany beat France?";
                    //Smashed through the Maginot Line, Hit the from behind, Invaded through belgium**, attack from italy
                    buttons[0].GetComponentInChildren<Text>().text = "Smashed through the Maginot Line";
                    buttons[1].GetComponentInChildren<Text>().text = "Hit the from behind Beans";
                    buttons[2].GetComponentInChildren<Text>().text = "Invaded through Belgium"; //correct
                    buttons[3].GetComponentInChildren<Text>().text = "Attack from Italy";
                    correct = 2;
                    break;
                case 9:
                    question.text = "When was the Communist Party founded?";
                    //June 1902, August 1918, May 1911, May 1917**
                    buttons[0].GetComponentInChildren<Text>().text = "June 1902";
                    buttons[1].GetComponentInChildren<Text>().text = "August 1918";
                    buttons[2].GetComponentInChildren<Text>().text = "May 1911";
                    buttons[3].GetComponentInChildren<Text>().text = "May 1917"; //correct
                    correct = 3;
                    break;
                case 8:
                    question.text = "When was the Nazi Party founded?";
                    //22 February 1920, 19 February 1920, 24 February 1920**, 22 February 1922
                    buttons[0].GetComponentInChildren<Text>().text = "22 February 1920";
                    buttons[1].GetComponentInChildren<Text>().text = "19 February 1920";
                    buttons[2].GetComponentInChildren<Text>().text = "24 February 1920";//correct
                    buttons[3].GetComponentInChildren<Text>().text = "22 February 1922";
                    correct = 2;
                    break;
                case 7:
                    question.text = "When was Christianity founded?";
                    //1st century**, 2nd century, 3rd century, 4th century
                    buttons[0].GetComponentInChildren<Text>().text = "1st century"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "2nd century";
                    buttons[2].GetComponentInChildren<Text>().text = "3rd century";
                    buttons[3].GetComponentInChildren<Text>().text = "4th century";
                    correct = 0;
                    break;
                case 6:
                    question.text = "Which Roman general defeated Gaul?";
                    //Julius Caesar**, Julius Baer, Julius Randle, Julius Hoffman
                    buttons[0].GetComponentInChildren<Text>().text = "Julius Caesar";//correct
                    buttons[1].GetComponentInChildren<Text>().text = "Julius Baer";
                    buttons[2].GetComponentInChildren<Text>().text = "Julius Randle";
                    buttons[3].GetComponentInChildren<Text>().text = "Julius Hoffman";
                    correct = 0;
                    break;
                case 5:
                    question.text = "When did Rome conquer Britannia(Britain)?";
                    //47 CE, 43 AD**, 26 BC, 35 CE
                    buttons[0].GetComponentInChildren<Text>().text = "47 CE";
                    buttons[1].GetComponentInChildren<Text>().text = "43 AD";//correct
                    buttons[2].GetComponentInChildren<Text>().text = "26 BC";
                    buttons[3].GetComponentInChildren<Text>().text = "35 CE";
                    correct = 1;
                    break;
                case 4:
                    question.text = "When did Rome conquer Gaul(France)?";
                    //121 BC**, 121 CE, 112 BC, 112 CE
                    buttons[0].GetComponentInChildren<Text>().text = "121 BC"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "121 CE";
                    buttons[2].GetComponentInChildren<Text>().text = "112 BC";
                    buttons[3].GetComponentInChildren<Text>().text = "112 CE";
                    correct = 0;
                    break;
                case 3:
                    question.text = "When did the Gauls sack Rome?";
                    //July 18,387 B.C**, Jun 18,384 B.C, July 16,387 B.C, Jun 18,388 B.C
                    buttons[0].GetComponentInChildren<Text>().text = "LJuly 18,387 B.Cettuce"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "Jun 18,384 B.C";
                    buttons[2].GetComponentInChildren<Text>().text = "July 16,387 B.C";
                    buttons[3].GetComponentInChildren<Text>().text = "Jun 18,388 B.C";
                    correct = 0;
                    break;
                case 2:
                    question.text = "What was Rome’s first light cavalry called?";
                    //Light cavalry, Auxiliary, Man on a horse, Equites**
                    buttons[0].GetComponentInChildren<Text>().text = "Light cavalry";
                    buttons[1].GetComponentInChildren<Text>().text = "Auxiliary";
                    buttons[2].GetComponentInChildren<Text>().text = "Man on a horse";
                    buttons[3].GetComponentInChildren<Text>().text = "Equites"; //correct
                    correct = 3;
                    break;
                case 1:
                    question.text = "What was Rome's first infantry called?";
                    //Foot Squire, Infantry, Hastati**, Heavy Infantry
                    buttons[0].GetComponentInChildren<Text>().text = "Foot Squire";
                    buttons[1].GetComponentInChildren<Text>().text = "Infantry";
                    buttons[2].GetComponentInChildren<Text>().text = "Hastati";//correct
                    buttons[3].GetComponentInChildren<Text>().text = "Heavy Infantry";
                    correct = 2;
                    break;
                case 0:
                    question.text = "In the early days of classical Romanian civilization, what was Rome’s government called?";
                    //Roman Republic**, Roman Kingdom, Roman Empire, Roman State
                    buttons[0].GetComponentInChildren<Text>().text = "Roman Republic"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "Roman Kingdom";
                    buttons[2].GetComponentInChildren<Text>().text = "Roman Empire";
                    buttons[3].GetComponentInChildren<Text>().text = "Roman State";
                    correct = 0;
                    break;
            }
        }      
    }

    private void OnTriggerEnter(Collider enter)
    {
        PlayerPrefs.SetInt("option", 5);
        if (enter.CompareTag("Player") && (answered == false))
        {
            istriggered = true;
            pc.froze = true;
            questionRandom();
            answers.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        option = PlayerPrefs.GetInt("option");
        if (option == correct && PlayerPrefs.GetInt("CheckDifficulty", 0) == 0)
        {            
            if (answered == false)
            {
            GM.score += 5;
            answered = true;
            }
            open = true;
            pc.froze = false;
            answers.SetActive(false);
            question.text = "";
            return;
        }
        else if (option == correct && PlayerPrefs.GetInt("CheckDifficulty", 1) == 1)
        {
            if (answered == false)
            {
                GM.score += 50;
                answered = true;
            }
            open = true;
            pc.froze = false;
            answers.SetActive(false);
            question.text = "";
            return;
        }
        else if (option == correct && PlayerPrefs.GetInt("CheckDifficulty", 2) == 2)
        {
            if (answered == false)
            {
                GM.score += 500;
                answered = true;
            }
            open = true;
            pc.froze = false;
            answers.SetActive(false);
            question.text = "";
            return;
        }
    }
    /*private void OnTriggerExit(Collider exit)
    {
        if (exit.CompareTag("Player"))
        {
            istriggered = false;
            open = false;
        }
        question.text = "";
        answers.active = false;
    }*/
}
