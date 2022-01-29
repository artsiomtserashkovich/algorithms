using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode.Stack
{
    public class AsteroidCollision
    {
        public int[] GetAsteroidCollisions(int[] asteroids) 
        {
            var stack = new Stack<int>();
        
            foreach(var asteroid in asteroids)
            {
                if(asteroid > 0)
                {
                    stack.Push(asteroid);    
                }
                else
                {
                    var solved = false;
                    while(!solved)
                    {
                        if(stack.Any())
                        {
                            var towardsAsteroid = stack.Peek();
                        
                            if(towardsAsteroid < 0)
                            {
                                stack.Push(asteroid);
                                solved = true;
                            }
                            else if(Math.Abs(asteroid) == towardsAsteroid)
                            {
                                stack.Pop();
                                solved = true;
                            }
                            else if(Math.Abs(asteroid) > towardsAsteroid)
                            {
                                stack.Pop();
                            }
                            else 
                            {
                                solved = true;  
                            }
                        }
                        else
                        {
                            stack.Push(asteroid);
                            solved = true;
                        }
                    }
                }
            }
        
            return stack.Reverse().ToArray();
        }
    }
}