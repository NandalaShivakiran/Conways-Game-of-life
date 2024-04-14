using UnityEngine;

namespace oompe.lib
{
    public class Rectangle
    {
        private float x, y, width, height;
        private GameObject primitive;
        private GameObject root;
        private SpriteRenderer spriteRenderer;
        private Texture2D texture2D;
        private Rect rect;
        private Sprite sprite;
        private Color color;
        private float thickness;
        private float spacing;

        public Rectangle(GameObject root, float x, float y, float width, float height, float spacing = 0.1f)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.root = root;
            this.thickness = 0.1f;
            this.spacing = spacing;
        }

        public void SetThickness(float thickness)
        {
            this.thickness = thickness;
        }

        public void Draw(Color color)
        {
            this.color = color;
            CreatePrimitive();
        }

        public void Draw()
        {
            CreatePrimitive();
        }

        private protected GameObject CreatePrimitive()
        {
            this.primitive = new GameObject();
            this.primitive.transform.SetParent(this.root.transform);
            
            float spacedX = x + spacing;
            float spacedY = y + spacing;

            this.primitive.transform.position = new Vector3(spacedX, spacedY, 0);

            this.spriteRenderer = this.primitive.AddComponent<SpriteRenderer>();
            this.spriteRenderer.color = color;
            this.texture2D = new Texture2D((int)(this.width), (int)(this.height));
            this.rect = new Rect(0, 0, this.width, this.height);
            this.sprite = Sprite.Create(this.texture2D, this.rect, new Vector2(0.5f, 0.5f), 1f);
            this.spriteRenderer.sprite = this.sprite;
            return this.primitive;
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }

        public double GetArea()
        {
            return this.rect.width * this.rect.height;
        }

        public bool IsInside(double px, double py)
        {
            return this.rect.Contains(new Vector2((float)px, (float)py));
        }
    }
}
