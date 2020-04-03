using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine;

public class CodeManager : MonoBehaviour
{
    [SerializeField] InputField inputField; //type du texte de l'inputField est un 'string'
    [SerializeField] Text console;

    [SerializeField] GameObject levelManager;

    private int nbErrors = 0;

    private int errorlvl1;
    private int errorlvl2;
    private int errorlvl3;

    private int currentLevel;

    private void Update()
    {
        currentLevel = levelManager.GetComponent<LevelManager>().level;
    }

    public void SubmitCode()
    {
        console.text = "";
        string regexPattern = @"\w+";
        Regex regex;
        regex = new Regex(regexPattern);
        MatchCollection instructions;

        string codeIn = inputField.text;

        string[] s_instructions;
        s_instructions = new string[codeIn.Length];

        instructions = regex.Matches(codeIn);


        for (int i = 0; i < instructions.Count; i++)
        {
            s_instructions[i] = instructions[i].ToString();
        }

        if (s_instructions.Length > 0)//Si InputField contient bien quelque chose
        {
            if (GameObject.Find(s_instructions[0])) //Si l'objet sélectionné existe
            {
                GameObject obj = GameObject.Find(s_instructions[0] + "_object");

                if (s_instructions[1] == "style")
                {
                    switch (s_instructions[2])
                    {
                        //case "color":
                        //    string color = s_instructions[3];
                        //    //obj.GetComponent<Shader>().;
                        //    break;

                        case "width":
                            int newWidth = int.Parse(s_instructions[3]);
                            obj.transform.localScale = new Vector3(newWidth, obj.transform.localScale.y, obj.transform.localScale.z);
                            break;

                        case "height":
                            int newHeight = int.Parse(s_instructions[3]);
                            newHeight /= 10;
                            obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y, newHeight); 
                            break;

                        case "transform":

                            if (s_instructions[3] == "rotate")
                            {
                                if (s_instructions[5] != "deg")
                                {
                                    Error("\nThe attribute \"" + instructions[5] + "\" doesn't exist in this context. Use \"deg\" instead!");
                                }
                                else
                                {
                                    int newRotation;
                                    bool isNumber = int.TryParse(s_instructions[4], out newRotation);

                                    if (isNumber)
                                    {
                                        newRotation *= -1;
                                        obj.transform.Rotate(new Vector3(obj.transform.rotation.x, obj.transform.rotation.y, newRotation));
                                    }
                                    else
                                    {
                                        Error("\nThe first value in the parenthesis has to be a number!");
                                    }
                                }
                            }
                            else
                            {
                                Error("\nThe attribute \"" + s_instructions[3] + "\" is unknown");
                            }
                            break;

                        case "top":
                            if (s_instructions[0] == "wall")
                            {
                                int newUp = int.Parse(s_instructions[3]);
                                newUp /= 10;
                                obj.transform.Translate(Vector3.forward * newUp);
                            }
                            else if(s_instructions[0] == "tree")
                            {
                                ConsoleMessageWithoutError("You cannot push the tree up because it is planted in the ground...");
                            }
                            else
                            {
                                ConsoleMessageWithoutError("You cannont push this object up because it is far too heavy...");
                            }

                            break;

                        case "left":

                            if(s_instructions[0] == "tomb")
                            {
                                int newLeft = int.Parse(s_instructions[3]);
                                newLeft /= 10;
                                obj.transform.Translate(Vector3.left * -newLeft);
                            }
                            else
                            {
                                ConsoleMessageWithoutError("You cannot move this object in this direction because another element is blocking the way...");
                            }

                            break;

                        case "right": //Inutilisable dans le jeu mais fonctionnel
                            if (s_instructions[0] == "")
                            {
                                int newRight = int.Parse(s_instructions[3]);
                                newRight /= 10;
                                obj.transform.Translate(Vector3.right * -newRight);
                            }
                            else
                            {
                                ConsoleMessageWithoutError("You cannot move this object in this direction because another element is blocking the way...");
                            }

                            break;

                        case "bottom": //Inutilisable dans le jeu mais fonctionnel
                            if (s_instructions[0] == "")
                            {
                                int newBottom = int.Parse(s_instructions[3]);
                                newBottom /= 10;
                                obj.transform.Translate(Vector3.back * newBottom);
                            }
                            else
                            {
                                ConsoleMessageWithoutError("You cannot move this object in this direction because another element is blocking the way...");
                            }

                            break;

                        default:
                            Error("\nThe attribute \"" + s_instructions[2] + "\" is unknown.");
                            break;
                    }

                }
                else
                {
                    Error("\nThe attribute \"" + s_instructions[1] + "\" is unknown.");
                }

            }
            else //si l'objet sélectionné est inconnu
            {

                Error("\nThe object \"" + s_instructions[0] + "\" doesn't exist in the scene. Try another tag!");
            }
            nbErrors = 0;
        }
        else
        {
            Error("\nThe skeleton will not know what to do if you don't tell him anything... :/");
        }

    }//fin fonction SubmitCode

    void Error(string a_errorTxt)
    {
        nbErrors++;
        string s_nbError = nbErrors.ToString();
        string textError = "";

        textError += s_nbError + " Error(s)\n" + a_errorTxt;
        console.text += textError;

        switch (currentLevel)
        {
            case 1:
                errorlvl1++;
                PlayerPrefs.SetInt("errorLvl1", errorlvl1);
                break;

            case 2:
                PlayerPrefs.SetInt("errorLvl2", errorlvl2);
                errorlvl2++;
                break;

            case 3:
                PlayerPrefs.SetInt("errorLvl3", errorlvl3);
                errorlvl3++;
                break;
        }
    }

    void ConsoleMessageWithoutError(string textConsole)
    {
        textConsole += "\n\nFind another way (if you do not manage to find the answer, don't hesitate to use the \"?\" button)!";
        console.text += textConsole;
    }
}//fin script
