using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorQuestion : MonoBehaviour
{
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
    private bool answered;
    public Text question;
    public GameObject answers;
    public PlayerControl pc;
    public Button[] buttons;
    public int correct;

    private void Start()
    {
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
        if (istriggered == true)
        {
            questionNumberEasy += 1f;
            //questionNumberNormal += 0.5f;
            //questionNumberHard += 0.5f;
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
                    correct = 3;
                    break;
                case 12:
                    question.text = "When is Singapore's National Day?";
                    //Monday, 8 August**/ Monday, 7 August/ Monday, 10 August/ Monday, 9 August
                    buttons[0].GetComponentInChildren<Text>().text = "8th August"; //correct
                    buttons[1].GetComponentInChildren<Text>().text = "7th August";
                    buttons[2].GetComponentInChildren<Text>().text = "10th August";
                    buttons[3].GetComponentInChildren<Text>().text = "9th August";
                    correct = 0;
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
                    question.text= "Who is Singapore’s current Prime Minister?";
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
            switch(questionNumberNormal)
            {
                case 19:
                    question.text = "What does one have but can never obtain?";
                    //Faith**, Books, Desire, Looks
                    break;
                case 18:
                    question.text = "Which of the following is not true about humans?";
                    //Having more than 2 lungs, Having more than 1 heart. We hibernate**, All of the Above
                    break;
                case 17:
                    question.text = "What do all nations have in common?";
                    //A leader, People, Resources, A God
                    break;
                case 16:
                    question.text = "What do all Singaporeans have in common?";
                    //SingPass**, National Service, Nerds, Freedom!
                    break;
                case 15:
                    question.text = "Which of the following items do most people have?";
                    //Coins, Phones, Cards, Clothes**
                    break;
                case 14:
                    question.text = "Which of the following do human’s body have?";
                    //Food, Light, Cells**, Electrum
                    break;
                case 13:
                    question.text = "What is the same characteristic between Solid, Liquid and Gas?";
                    //They are all a Matter**, They have the same component, There is nothing similar, They exist
                    break;
                case 12:
                    question.text = "What do you call someone who knows all?";
                    //A sage, A Man, A wiseman, Someone who ask questions**
                    break;
                case 11:
                    question.text = "What do you call someone who wields a sword?";
                    //Swordsmen/swordswomen, Sword Master, Soldier, A man with a sword
                    break;
                case 10:
                    question.text = "What do sailors do best?";
                    //Playing around, Sailing the seas**, Fighting, Singing sea shanties
                    break;
                case 9:
                    question.text = "Which province is part of Europe?";
                    //Singapore, Texas, Province**, Japan
                    break;
                case 8:
                    question.text = "When did the Great Emu War start?";
                    //2 November 1932**, 5 November 1932, 16 November 1932, was there really an emu war?
                    break;
                case 7:
                    question.text = "Which of the animals hibernates?";
                    //Wolf, Seagulls, Skunks**, All of the above
                    break;
                case 6:
                    question.text = "Which of the following applications is used for tracing people’s locations?";
                    //Trace together**, Google Map, Translator, All of the above
                    break;
                case 5:
                    question.text = "Which of the following applications is used for meetings?";
                    //Zoom, Discord, Mircosoft Teams, All of the above**
                    break;
                case 4:
                    question.text = "Which type of flowers exist in the world?";
                    //Fire, Angelica, Guklulla, Cypripedium Calceolus**
                    break;
                case 3:
                    question.text = "What is Singapore’s national flower called?";
                    //Chrysanthemum, Plum Blossom, Cornus Canadensis, Hybrid Orchid**
                    break;
                case 2:
                    question.text = "What is the name of the greatest game in 2001?";
                    //Halo: Combat Evolve**, Final Fantasy 1, Baldur’s Gate: Dark Alliance, Runescape
                    break;
                case 1:
                    question.text = "What breathes, consumes, and grows, but was and never will be alive?";
                    //Stomach, Fire**, Air, Earth
                    break;
                case 0:
                    question.text = "Which of the following plants is not a vegetable?";
                    //Lettuce, Green Beans, Beets, Oranges**
                    break;
            }
            switch(questionNumberHard)
            {
                case 19:
                    question.text = "Which company made halo?";
                    //343 Industries, Bungie**, nintendo, Microsoft
                    break;
                case 18:
                    question.text = "How many halo game is there?";
                    //2, 6, 8, 13**
                    break;
                case 17:
                    question.text = "What is not true about matter?";
                    //Matter can be destroyed**, Matters can be converted, Matters have 3 states, Matter can change
                    break;
                case 16:
                    question.text = "Which of the following is true about matter?";
                    //Matter has mass**, Matter is not made up of atoms, Matter only have a liquid state, Matter can be destroyed
                    break;
                case 15:
                    question.text = "During WWII, when did america send aid to britain?";
                    //March 1941**, March 1932, May 1942, December 1941
                    break;
                case 14:
                    question.text = "When was the treaty of versailles?";
                    //June 12 1918, June 28, 1919**, July 29 1915, July 18, 1919
                    break;
                case 13:
                    question.text = "What is blitzkrieg?";
                    //Swift victory**, Continuous battle, Aerial battle, wait and see
                    break;
                case 12:
                    question.text = "How did hitler die?";
                    //Killed in Action, Suicide**, Hanged, sentence to death.
                    break;
                case 11:
                    question.text = "When did Germany attack russia?";
                    //12 June 1942, 28 July 1941, 12 June 1941, 22 June 1941**
                    break;
                case 10:
                    question.text = "During world war II, how did Germany beat France?";
                    //Smashed through the Maginot Line, Hit the from behind, Invaded through belgium**, attack from italy
                    break;
                case 9:
                    question.text = "When was the Communist Party founded?";
                    //June 1902, August 1918, May 1911, May 1917**
                    break;
                case 8:
                    question.text = "When was the Nazi Party founded?";
                    //22 February 1920, 19 February 1920, 24 February 1920**, 22 February 1922
                    break;
                case 7:
                    question.text = "When was christianity founded?";
                    //1st century**, 2nd century, 3rd century, 4th century
                    break;
                case 6:
                    question.text = "Which Roman general defeated Gaul?";
                    //Julius Caesar**, Julius Baer, Julius Randle, Julius Hoffman
                    break;
                case 5:
                    question.text = "When did Rome conquer Britannia(Britain)?";
                    //47 CE, 43 AD**, 26 BC, 35 CE
                    break;
                case 4:
                    question.text = "When did Rome conquer Gaul(France)?";
                    //121 BC**, 121 CE, 112 BC, 112 CE
                    break;
                case 3:
                    question.text = "When did the Gauls sack rome?";
                    //July 18,387 B.C**, Jun 18,384 B.C, July 16,387 B.C, Jun 18,388 B.C
                    break;
                case 2:
                    question.text = "What was Rome’s first light cavalry called?";
                    //Light cavalry, Auxiliary, Man on a horse, Equites**
                    break;
                case 1:
                    question.text = "What was Rome's first infantry called?";
                    //Foot Squire, Infantry, Hastati**, Heavy Infantry
                    break;
                case 0:
                    question.text = "In the early days of classical Romanian civilization, what was Rome’s government called?";
                    //Roman Republic**, Roman Kingdom, Roman Empire, Roman State
                    break;
            }


        }
    }

    private void OnTriggerEnter(Collider enter)
    {
        if (enter.CompareTag("Player"))
        {
            istriggered = true;
            pc.froze = true;
            if (answered == true)
            {
                open = true;
                pc.froze = false;
            }

        }
        questionRandom();
        answers.active = true;
    }

    private void OnTriggerExit(Collider exit)
    {
        if (exit.CompareTag("Player"))
        {
            istriggered = false;
            open = false;
        }
        question.text = "";
        answers.active = false;
    }
}
