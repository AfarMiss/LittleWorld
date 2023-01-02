using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionMenu : MonoBehaviour
{
    private List<InteractionOption> options;
    [SerializeField] private GameObject optionPrefab;
    public void BindData(List<optionStruct> options)
    {
        this.options = new List<InteractionOption>();
        foreach (var optionContent in options)
        {
            var optionObject = Instantiate(optionPrefab, this.transform);
            var option = optionObject.GetComponent<InteractionOption>();
            option.BindData(optionContent);
            this.options.Add(option);
        }
    }

    private void Update()
    {
        //Debug.Log($"InputUtils.GetMousePosition():{InputUtils.GetMousePosition()}");
        if (options == null) return;
        foreach (var item in options)
        {
            var rect = item.GetComponent<RectTransform>();

            var screenRect = new Rect(rect.position.x, rect.position.y, rect.rect.width, rect.rect.height);
            Debug.Log($"{rect.name}:{screenRect}");
            if (screenRect.Contains(GameController.Instance.mousePosition))
            {
                Debug.Log($"{item.name} is raycasting");
                item.SetFocus(true);
                continue;
            }
            item.SetFocus(false);
        }
    }
}
