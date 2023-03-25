using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeospectraApp.Driver
{
    public class ByteBuffer
    {
        private byte[] buffer;
        private int position;
        private int limit;
        private int mark = -1;

        public ByteBuffer(int size)
        {
            buffer = new byte[size];
            limit = size;
            position = 0;
        }

        public ByteBuffer(byte[] data)
        {
            buffer = data;
            limit = data.Length;
            position = 0;
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public byte[] Array
        {
            get { return buffer; }
        }

        public int Length
        {
            get { return buffer.Length; }
        }

        public int Limit
        {
            get { return limit; }
            set
            {
                if (value < 0 || value > buffer.Length)
                {
                    throw new ArgumentException("Invalid limit");
                }
                limit = value;
                if (position > limit)
                {
                    position = limit;
                }
                if (mark > limit)
                {
                    mark = -1;
                }
            }
        }

        public int Remaining
        {
            get { return limit - position; }
        }

        public byte Get()
        {
            if (position >= limit)
            {
                throw new IndexOutOfRangeException();
            }
            return buffer[position++];
        }

        public byte[] Get(int length)
        {
            if (position + length > limit)
            {
                throw new IndexOutOfRangeException();
            }
            byte[] data = new byte[length];
            System.Array.Copy(buffer, position, data, 0, length);
            position += length;
            return data;
        }

        public void Put(byte b)
        {
            if (position >= limit)
            {
                throw new IndexOutOfRangeException();
            }
            buffer[position++] = b;
        }

        public void Put(byte[] data)
        {
            Put(data, 0, data.Length);
        }

        public void Put(byte[] data, int offset, int length)
        {
            if (position + length > limit)
            {
                throw new IndexOutOfRangeException();
            }
            System.Array.Copy(data, offset, buffer, position, length);
            position += length;
        }

        public void PutInt(int value)
        {
            byte[] data = BitConverter.GetBytes(value);
            Put(data);
        }

        public void PutLong(long value)
        {
            byte[] data = BitConverter.GetBytes(value);
            Put(data);
        }

        public void PutDouble(double value)
        {
            byte[] data = BitConverter.GetBytes(value);
            Put(data);
        }

        public int GetInt()
        {
            if (position + sizeof(int) > limit)
            {
                throw new IndexOutOfRangeException();
            }
            int value = BitConverter.ToInt32(buffer, position);
            position += sizeof(int);
            return value;
        }

        public long GetLong()
        {
            if (position + sizeof(long) > limit)
            {
                throw new IndexOutOfRangeException();
            }
            long value = BitConverter.ToInt64(buffer, position);
            position += sizeof(long);
            return value;
        }

        public double GetDouble()
        {
            if (position + sizeof(double) > limit)
            {
                throw new IndexOutOfRangeException();
            }
            double value = BitConverter.ToDouble(buffer, position);
            position += sizeof(double);
            return value;
        }
        public long GetLong(int index)
        {
            if (index + sizeof(long) > limit)
                throw new IndexOutOfRangeException();
            return BitConverter.ToInt64(buffer, index);
        }

        public int GetInt(int index)
        {
            if (index + sizeof(int) > limit)
                throw new IndexOutOfRangeException();
            return BitConverter.ToInt32(buffer, index);
        }
        
        public short GetShort(int index)
        {
            if (index + sizeof(short) > limit)
                throw new IndexOutOfRangeException();
            return BitConverter.ToInt16(buffer, index);
        }

        public double GetDouble(int index)
        {
            if (index + sizeof(double) > limit)
                throw new IndexOutOfRangeException();
            return BitConverter.ToDouble(buffer, index);
        }
        public void Flip()
        {
            limit = position;
            position = 0;
            mark = -1;
        }
        public byte[] ToArray()
        {
            byte[] array = new byte[limit];
            System.Array.Copy(buffer, 0, array, 0, limit);
            return array;
        }

    }
}
