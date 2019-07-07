﻿namespace Rogue.Drawing.SceneObjects.Map
{
    using Rogue.Control.Events;
    using Rogue.Control.Keys;
    using Rogue.Control.Pointer;
    using Rogue.Drawing.SceneObjects.Dialogs.NPC;
    using Rogue.Drawing.SceneObjects.Effects;
    using Rogue.Entites.Alive;
    using Rogue.Entites.Animations;
    using Rogue.Map;
    using Rogue.Map.Objects;
    using Rogue.Types;
    using Rogue.View.Interfaces;
    using System;
    using System.Collections.Generic;

    public class NPCSceneObject : MoveableSceneObject<NPC>
    {
        public NPCSceneObject(PlayerSceneObject playerSceneObject, GameMap location, NPC mob, Rectangle defaultFramePosition)
            : base(playerSceneObject, mob, location, mob, mob.NPCEntity, defaultFramePosition)
        {
            this.Image = mob.Tileset;
            Left = mob.Location.X;
            Top = mob.Location.Y;
            Width = 1;
            Height = 1;

            mob.Die += () =>
            {
                this.Destroy?.Invoke();
            };

            if (mob.NPCEntity.Idle != null)
            {
                this.SetAnimation(mob.NPCEntity.Idle);
            }

            LightTrigger = Global.Time
                .After(18).Do(AddTorchlight)
                .After(8).Do(RemoveTorchlight);
        }

        private TorchlightInHandsSceneObject torchlight;

        private void AddTorchlight()
        {
            torchlight = new TorchlightInHandsSceneObject();
            this.AddChild(torchlight);
        }

        private void RemoveTorchlight()
        {
            this.RemoveChild(torchlight);
            torchlight?.Destroy?.Invoke();
        }

        private readonly TimeTrigger LightTrigger;

        protected override void DrawLoop()
        {
            LightTrigger.Trigger();
            base.DrawLoop();
        }

        private NPCDialogue NPCDialogue;

        protected override void Action(MouseButton mouseButton)
        {
            playerSceneObject.StopMovings();
            NPCDialogue = new NPCDialogue(playerSceneObject, @object, this.DestroyBinding, this.ControlBinding);

            ShowEffects?.Invoke(NPCDialogue.InList<ISceneObject>());
        }

        protected override void StopAction()
        {
        }

        protected override Key[] KeyHandles => new Key[] { Key.LeftAlt };

        protected override Dictionary<int, (Direction dir, Vector vect, Func<Moveable, AnimationMap> anim)> DirectionMap => new Dictionary<int, (Direction, Vector, Func<Moveable, AnimationMap>)>
        {
            { 0,(Direction.Up, Vector.Minus, m=>
                {
                    if(torchlight != null)
                    {
                        torchlight.Left=0;
                    }
                    return m.MoveUp;
                })
            },
            { 1,(Direction.Down, Vector.Plus, m=>
                {
                    if(torchlight != null)
                    {
                        torchlight.Left=0;
                    }
                    return m.MoveDown;
                })
            },
            { 2,(Direction.Left, Vector.Minus, m=>
                {
                    if(torchlight != null)
                    {
                        torchlight.Left=0.4;
                    }
                    return m.MoveLeft;
                })
            },
            { 3,(Direction.Right, Vector.Plus, m=>
                {
                    if(torchlight != null)
                    {
                        torchlight.Left=0.2;
                    }
                    return m.MoveRight;
                })
            },
        };
    }
}