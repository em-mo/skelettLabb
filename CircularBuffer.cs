using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.SkeletonBasics
{
    class CircularBuffer
    {
        private int mSize;
        private float mTotalValue;
        private Node mHead;
        private Node mCurrent;

        public CircularBuffer(int size, float initializeValue)
        {
            int mSize = size;
            mTotalValue = initializeValue;

            Node previousNode = mHead = new Node(initializeValue, null);
            for (int i = 1; i < size; i++)
            {
                mCurrent = new Node(0, previousNode);
                previousNode = mCurrent;
            }

            mHead.mNext = mCurrent;
            mCurrent = mHead;
        }

        public void SetNextValue(float value) 
        {
            mTotalValue -= mCurrent.mData;
            mTotalValue += value;
            mCurrent.mData = value;
            mCurrent = mCurrent.mNext;
        }

        public float GetCurrent()
        {
            return mCurrent.mData;
        }

        public float GetTotal()
        {
            return mTotalValue;
        }

        public void Reset()
        {
            mTotalValue = 0;
            mCurrent = mHead;
            for (int i = 0; i < mSize; i++)
            {
                mCurrent.mData = 0;
                mCurrent = mCurrent.mNext;
            }
            mCurrent = mHead;
        }

        private class Node
        {
            public float mData;
            public Node mNext;
            public Node(float data, Node next)
            {
                mData = data;
                mNext = next;
            }
        }
    }
}
