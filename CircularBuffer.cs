using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.SkeletonBasics
{
    class CicularBuffer
    {
        private int mSize;
        private int mTotalValue;
        private Node mHead;
        private Node mCurrent;

        public CicularBuffer(int size)
        {
            int mSize = size;
            mTotalValue = 0;

            Node previousNode = mHead = new Node(0, null);
            for (int i = 1; i < size; i++)
            {
                mCurrent = new Node(0, previousNode);
                previousNode = mCurrent;
            }

            mHead.mNext = mCurrent;
            mCurrent = mHead;
        }

        public void setNextValue(int value) 
        {
            mTotalValue -= mCurrent.mData;
            mTotalValue += value;
            mCurrent.mData = value;
        }

        public int getTotal()
        {
            return mTotalValue;
        }

        private class Node
        {
            public int mData;
            public Node mNext;
            public Node(int data, Node next)
            {
                mData = data;
                mNext = next;
            }
        }
    }
}
