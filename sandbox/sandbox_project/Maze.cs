/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /*
    */
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
        /*
        Solution:
        - Get the positions of the x and y coordinates, and store them in a variable (type tuple)
        - Store the directions into the direction variable  and store its position
        - If direction to left is false throw a new exception saying "Can't go that way!"
        - Decrement the currX, if its allowed 
        */

        var positions = (_currX, _currY);
        var direction = _mazeMap[positions];

        if (direction[0] == false)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        else
        {
            _currX -= 1;
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        /*
        Solution:
        - Get the positions of the x and y coordinates, and store them in a variable (type tuple)
        - Store the directions into the direction variable  and store its position
        - If direction to right is false throw a new exception saying "Can't go that way!"
        - Increment the currX, if its allowed.
        */
        var positions = (_currX, _currY);
        var direction = _mazeMap[positions];

        if (direction[1] == false)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        else
        {
            _currX += 1;
        }

    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        /*
        Solution:
        - Get the positions of the x and y coordinates, and store them in a variable (type tuple)
        - Store the directions into the direction variable  and store its position
        - If direction upwards is false throw a new exception saying "Can't go that way!"
        - Decrement the currY, if its allowed.
        */
        var positions = (_currX, _currY);
        var direction = _mazeMap[positions];

        if (direction[2] == false)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        else
        {
            _currY -= 1;
        }

    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        /*
        Solution:
        - Get the positions of the x and y coordinates, and store them in a variable (type tuple)
        - Store the directions into the direction variable  and store its position
        - If direction downwards is false throw a new exception saying "Can't go that way!"
        - Increment the currY, if its allowed.
        */
        var positions = (_currX, _currY);
        var direction = _mazeMap[positions];

        if (direction[3] == false)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        else
        {
            _currY += 1;
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}