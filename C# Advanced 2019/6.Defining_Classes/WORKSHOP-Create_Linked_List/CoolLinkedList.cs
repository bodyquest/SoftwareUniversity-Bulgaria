using System;
using System.Collections.Generic;
using System.Text;

namespace WORKSHOP_Create_Linked_List
{
    public class CoolLinkedList
    {
        private CoolNode head;
        private CoolNode tail;

        public class CoolNode
        {
            public CoolNode(object value)
            {
                this.Value = value;
            }
            public object Value { get; private set; }

            public CoolNode Next { get; set; }

            public CoolNode Previous { get; set; }

        }

        public int Count { get; private set; }

        public void AddHead(object value)
        {
            var newNode = new CoolNode(value);
            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                var oldHead = this.head;
                oldHead.Previous = newNode;
                newNode.Next = oldHead;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddTail(object value)
        {
            var newNode = new CoolNode(value);
            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                var oldTail = this.tail;
                oldTail.Previous = newNode;
                newNode.Next = oldTail;
                this.tail = newNode;
            }

            this.Count++;
        }

        public object Head
        {
            get
            {
                this.ValidateIfListIsEmpty();

                return this.head.Value;
            }
        }

        public object Tail
        {
            get
            {
                this.ValidateIfListIsEmpty();

                return this.tail.Value;
            }
        }

        public object RemoveHead()
        {
            this.ValidateIfListIsEmpty();
            
            var value = this.head.Value;

            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                var newHead = this.head.Next;
                newHead.Previous = null;
                this.head.Next = null; 
                this.head = newHead;
            }

            this.Count--;
            return value;
        }

        public object RemoveTail()
        {
            this.ValidateIfListIsEmpty();

            var value = this.tail.Value;
            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                var oldTail = this.tail;
                var newTail = this.tail.Previous;

            }

            this.Count--;
            return value;
        }

        private void ValidateIfListIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cool linked list is empty.");
            }
        }
    }
}
