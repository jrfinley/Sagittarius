using UnityEngine;
using System.Collections;
using System.Text;
using System.Linq;
using System.IO;

public class GenerateLoader : MonoBehaviour
{
    private GameController gameController;
    private int count = 0;

    public GameObject actorObj;

    const int MAX_PATH = 260;

    private static string dataPath = string.Empty;


    void Start ()
    {
        gameController = FindObjectOfType<GameController>();

        CheckPAth("C:/Users/Gonzales/AppData/LocalLow/GAM53/Sagittarius\actors.json");
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "actors.json");//path combiner combines strings we put in with backslash, last bit is file name



        if (System.IO.File.Exists(Path.Combine(Application.persistentDataPath, "actors.json")))
        {
            StartCoroutine(CallLoaderSpawn());
            Debug.Log(System.IO.File.Exists("C:/ Users / Gonzales / AppData / LocalLow / GAM53 / Sagittarius\actors.json"));
        }
        else
        {
            StartCoroutine(CallCreateFakeLoader());
            Debug.Log(System.IO.File.Exists("C:/ Users / Gonzales / AppData / LocalLow / GAM53 / Sagittarius\actors.json"));
        }
    }

    private static void CheckPAth(string path)
    {
        if(path.Length >= MAX_PATH)
        {
            CheckFile_LongPath(path);
        }
        else if (!File.Exists(path))
        {
            Debug.Log(" * File: " + path + " does not exist.");
        }
    }

    private static void CheckFile_LongPath(string path)
    {
        string[] subpaths = path.Split('\\');
        StringBuilder sbNewPath = new StringBuilder(subpaths[0]);
        for(int i = 1; i < subpaths.Length; i++)
        {
            if(sbNewPath.Length + subpaths[i].Length >= MAX_PATH)
            {
                subpaths = subpaths.Skip(i).ToArray();
                break;
            }
            sbNewPath.Append("\\" + subpaths[i]);
        }
        DirectoryInfo dir = new DirectoryInfo(sbNewPath.ToString());
        bool foundMatch = dir.Exists;
        if (foundMatch)
        {
            int i = 0;
            while (i < subpaths.Length - 1 && foundMatch)
            {
                foundMatch = false;
                foreach(DirectoryInfo subDir in dir.GetDirectories())
                {
                    if(subDir.Name == subpaths[i])
                    {
                        dir = subDir;
                        foundMatch = true;
                        break;
                    }
                }
                i++;
            }
            if (foundMatch)
            {
                foundMatch = false;
                foreach(FileInfo fi in dir.GetFiles())
                {
                    if(fi.Name == subpaths[subpaths.Length - 1])
                    {
                        foundMatch = true;
                        break;
                    }
                }
            }
        }
        if (!foundMatch)
        {
            Debug.Log(" * file: " + path + " does not exist");
        }
    }

    IEnumerator CallCreateFakeLoader()
    {
        yield return new WaitForSeconds(.21f);
        Instantiate(actorObj, transform.position, Quaternion.identity);
        //dataPath = System.IO.Path.Combine(Application.persistentDataPath, "actors.json");
    }

    IEnumerator CallLoaderSpawn()
    {
        yield return new WaitForSeconds(.21f);
        if(count < 1)
        {
            gameController.Load();
            Debug.Log("Created Loader" + count + " Times");
            count++;
            Actor loadedActor = FindObjectOfType<Actor>();
            if(loadedActor != null)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
