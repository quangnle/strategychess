namespace StrategyChess
{
    public interface IChessPiece
    {
        int Id { get; set; }
        ChessPieceType PieceType { get; set; }
        int HP { get; set; }
        int Speed { get; set; }
        int Range { get; set; }
    }
}