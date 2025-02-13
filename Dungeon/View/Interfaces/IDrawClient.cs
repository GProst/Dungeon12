﻿namespace Dungeon.View.Interfaces
{
    using Dungeon.Types;

    public interface IDrawClient : ICamera
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        /// <returns>After 1 draw circle</returns>
        Callback SetScene(IScene scene);

        Point MeasureText(IDrawText drawText,ISceneObject parent=default);

        Point MeasureImage(string image);

        void SaveObject(ISceneObject sceneObject, string path = default, Point offset = default, string runtimeCacheName = null);

        void Animate(IAnimationSession animationSession);

        void Drag(ISceneObject @object, ISceneObject area = null);

        void Drop();

        void Clear(IDrawColor drawColor=default);

        void SetCursor(string texture);

        /// <summary>
        /// Полностью кэширует объект, в т.ч. и маску
        /// </summary>
        /// <param name="object"></param>
        void CacheObject(ISceneObject @object);

        /// <summary>
        /// Кэширование изображения
        /// </summary>
        /// <param name="image">Путь к изображению</param>
        void CacheImage(string image);

        /// <summary>
        /// Создать эффект который зависит от платформы
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEffect GetEffect(string name);
    }
}