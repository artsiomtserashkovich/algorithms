using System.Collections.Generic;
using Algorithms.LeetCode.Tree;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.LeetCode.Tests.Tree
{
    public class FindLeafsOfBinaryTreeTests 
    {
        [TestCaseSource(nameof(GetFindLeafsOfBinaryTreeCases))]
        public void Solution(FindLeafsOfBinaryTree.TreeNode root, IList<IList<int>> result)
        {
            new FindLeafsOfBinaryTree().GetLeafsOfBinaryTree(root).Should().BeEquivalentTo(result);
        }
        
        [TestCaseSource(nameof(GetFindLeafsOfBinaryTreeCases))]
        public void SolutionV2(FindLeafsOfBinaryTree.TreeNode root, IList<IList<int>> result)
        {
            new FindLeafsOfBinaryTree().GetLeafsOfBinaryTreeV2(root).Should().BeEquivalentTo(result);
        }

        public static IEnumerable<TestCaseData> GetFindLeafsOfBinaryTreeCases()
        {
            yield return new TestCaseData(
                new FindLeafsOfBinaryTree.TreeNode(
                    val: 1,
                    left: new FindLeafsOfBinaryTree.TreeNode(
                        val: 2,
                        left: new FindLeafsOfBinaryTree.TreeNode(val: 4 ),
                        right: new FindLeafsOfBinaryTree.TreeNode(val: 5) ),
                    right: new FindLeafsOfBinaryTree.TreeNode(3)),
                new List<IList<int>>
                {
                    new List<int> {4, 5, 3},
                    new List<int> {2},
                    new List<int> {1},
                });
        }   
    }
}