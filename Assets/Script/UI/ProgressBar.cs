using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float verticalOffset = 0;
    public enum Mode
    {
        Normal,
        Invert
    }
    [SerializeField] private Mode mode;
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void UpdateProgressBar(float progress)
    {
        Show();
        progressImage.fillAmount = progress;
        if(progress >= 1)
        {
            Invoke("Hide",0.5f);
        }
    }
    void LateUpdate()
{
    if (Camera.main != null)
    {
            switch (mode)
            {
                case Mode.Normal:
                    verticalOffset = 0;
                    break;
                case Mode.Invert:
                    verticalOffset =-1.5f;
                    break;
                
            }
        // 1. 强制将 UI 锁在父物体的中心垂直线上
        // 我们只保留 Y 轴的高度偏移，X 和 Z 强行归零
        float heightOffset = 1.5f; // 你可以把这个定义成变量，在 Inspector 里调
        transform.localPosition = new Vector3(0, heightOffset, verticalOffset);
        // 2. 保持与摄像机平行
        transform.forward = Camera.main.transform.forward;

        
    }
}
}
