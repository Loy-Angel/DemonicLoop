using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    [Header("Componentes de la pantalla de carga")]
    [SerializeField] private Slider slider;
    [SerializeField] private Canvas _loadingCanvas;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _loadingCanvas.enabled = false;
    }

    // Carga la escena por el n�mero de posici�n.
    public async void LoadScene(int scene)
    {
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene);
        operation.allowSceneActivation = false; // Impide que se active la escena.

        _loadingCanvas.enabled = true;

        float progressValue;

        // Muestra por pantalla el progreso de carga de escena.
        do
        {
            await System.Threading.Tasks.Task.Delay(100);

            progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = Mathf.MoveTowards(slider.value, progressValue, 3 * Time.deltaTime);
        } while (operation.progress < 0.9f);

        slider.value = 1;

        operation.allowSceneActivation = true; // Permite que se active la escena.

        await System.Threading.Tasks.Task.Delay(1000);

        _loadingCanvas.enabled = false;
    }

    // Carga la escena por su nombre.
    public async void LoadSceneName(string scene)
    {
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene);
        operation.allowSceneActivation = false; // Impide que se active la escena.

        _loadingCanvas.enabled = true;

        float progressValue;

        // Muestra por pantalla el progreso de carga de escena.
        do
        {
            await System.Threading.Tasks.Task.Delay(100);

            progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = Mathf.MoveTowards(slider.value, progressValue, 3 * Time.deltaTime);
        } while (operation.progress < 0.9f);

        slider.value = 1;

        operation.allowSceneActivation = true; // Permite que se active la escena.

        await System.Threading.Tasks.Task.Delay(1000);

        _loadingCanvas.enabled = false;
    }

    void FixedUpdate()
    {
        // En el caso de no ser "Scene 1" activa el componente "Enter_Battle".
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Scene 1")
        {
            GetComponent<EnterBattle>().Start = true;
            GetComponent<EnterBattle>().enabled = true;
        }
        else
        {
            GetComponent<EnterBattle>().Start = false;
            GetComponent<EnterBattle>().enabled = false;
        }
    }
}
