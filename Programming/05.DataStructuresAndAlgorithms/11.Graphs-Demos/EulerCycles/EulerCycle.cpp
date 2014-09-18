//Finding and printing an Euler cycle in a Undirected graph

#include <iostream>
#include <vector>
#include <set>
#include <string>
#include <iterator>
#include <stdio.h>
#include <stdlib.h>

using namespace std;

vector<string> sampleInput;
vector<string> sampleInput2;
vector<string> sampleInput3;
vector<string> sampleInput4;
vector<string> sampleInput5;

void GenerateSampleInputs()
{
	sampleInput.push_back("6");
	sampleInput.push_back("011110");
	sampleInput.push_back("101101");
	sampleInput.push_back("110011");
	sampleInput.push_back("110011");
	sampleInput.push_back("101101");
	sampleInput.push_back("011110");

	sampleInput2.push_back("6");
	sampleInput2.push_back("000110");
	sampleInput2.push_back("001001");
	sampleInput2.push_back("010001");
	sampleInput2.push_back("100010");
	sampleInput2.push_back("100100");
	sampleInput2.push_back("011000");

	sampleInput3.push_back("6");
	sampleInput3.push_back("000110");
	sampleInput3.push_back("001101");
	sampleInput3.push_back("010001");
	sampleInput3.push_back("110011");
	sampleInput3.push_back("100100");
	sampleInput3.push_back("011100");

	sampleInput4.push_back("4");
	sampleInput4.push_back("0101");
	sampleInput4.push_back("1010");
	sampleInput4.push_back("0101");
	sampleInput4.push_back("1010");

	sampleInput5.push_back("6");
	sampleInput5.push_back("010111");
	sampleInput5.push_back("101000");
	sampleInput5.push_back("010100");
	sampleInput5.push_back("101000");
	sampleInput5.push_back("100001");
	sampleInput5.push_back("100010");
}

void PrintSampleInput(vector<string> input)
{
	copy(input.begin(), input.end(), ostream_iterator<string>(cout, "\n"));
}

void ReadSampleInput
        (vector<string> input, vector<set<int> >& vertexNeighbours, int& edgesLeft, bool& isEulerCandidate)
    {
		//int n = stoi(input[0]);
		int n;
		sscanf(input[0].c_str(), "%d", &n);
		int vertexCount;
		string line;
		set<int> emptySet;
        for (int i = 0; i < n; i++)
        {
			vertexNeighbours.push_back(emptySet);
			line = input[i+1];
            for (int j = 0; j < n; j++)
            {
				if (line[j] == '1') vertexNeighbours[i].insert(j);
            }
			vertexCount = vertexNeighbours[i].size();
			edgesLeft += vertexCount;
            if (vertexCount % 2 != 0)
            {
                isEulerCandidate = false;
                return;
            }
        }
	}

void PrintEulerCycleInUndirectedGraph(vector<string> input)
{
	//Representing the graph with the neighbours(edges) keeped for each vertex
	vector<set<int> > vertexNeighbours;

    //Getting the input
    int edgesLeft = 0;
    bool isEulerCandidate = true;
    ReadSampleInput(input, vertexNeighbours, edgesLeft, isEulerCandidate);

	//Euler cycle is only possible when all vertices are of even degree.
    if (!isEulerCandidate)
    {
		cout<<"No Euler cycles because of a vertex with odd degree!"<<endl;
        return;
    }

	vector<int> tempPath;
    vector<int> finalPath;

    //Choose the vertex to start with
	for (int i = 0; i < vertexNeighbours.size(); i++)
    {
		if (vertexNeighbours[i].size() > 0)
        {
			tempPath.push_back(i);
            break;
        }
    }

    int next;
    while (edgesLeft > 0)
    {
		if (vertexNeighbours[tempPath.back()].size() > 0)
        {
            //There is unvisited edge from current vertex leading to the next vertex
			next = *vertexNeighbours[tempPath.back()].begin();

            //Removing both edges because the graph is not-oriented
			vertexNeighbours[tempPath.back()].erase(next);
            vertexNeighbours[next].erase(tempPath.back());
            edgesLeft -= 2;

            //Moving to the next vertex
			tempPath.push_back(next);
        }
        else
        {
            //Small cycle finished
			finalPath.push_back(tempPath.back());
			tempPath.pop_back();
        }

        //No way to go from passed vertices but there are still edges left, so the graph is not connected
		if (tempPath.size() == 0)
        {
			cout<<"There is no Euler cycle because the graph is not connected!"<<endl;
            return;
        }
    }

    //Adding final left vertices to finalPath
	while (tempPath.size() > 0)
	{
		finalPath.push_back(tempPath.back());
		tempPath.pop_back();
	}

	cout<<"Printing Euler cycle:"<<endl;
	copy(finalPath.begin(), finalPath.end(), ostream_iterator<int>(cout, " "));
	cout<<endl;
}

int main()
{
	GenerateSampleInputs();

	PrintSampleInput(sampleInput);
	PrintEulerCycleInUndirectedGraph(sampleInput);

	cout<<endl;

	PrintSampleInput(sampleInput2);
	PrintEulerCycleInUndirectedGraph(sampleInput2);

	cout<<endl;

	PrintSampleInput(sampleInput3);
	PrintEulerCycleInUndirectedGraph(sampleInput3);

	cout<<endl;

	PrintSampleInput(sampleInput4);
	PrintEulerCycleInUndirectedGraph(sampleInput4);

	cout<<endl;

	PrintSampleInput(sampleInput5);
	PrintEulerCycleInUndirectedGraph(sampleInput5);
}