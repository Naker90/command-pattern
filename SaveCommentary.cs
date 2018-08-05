public class SaveCommentaryCommnad
{
  public int UserId { get; private set; }
  public int PictureId { get; private set; }
  public string Commentary { get; private set; }

  public static SaveCommentaryCommnad Build(
    int userId,
    int pictureId,
    string commentary)
  {
    if(IsCommentaryEmptyOrNull(commentary)){
      throw new CommentaryCanNotBeEmptyOrNullException();
    }

    return new SaveCommentaryCommnad(
      userId: userId,
      pictureId: pictureId,
      commentary: commentary);
  }

  private SaveCommentaryCommnad(
    int userId,
    int pictureId,
    string commentary)
  {
    UserId = userId;
    PictureId = pictureId;
    Commentary = commentary;
  }

  private static bool IsCommentaryEmptyOrNull(string commentary)
  {
    return string.IsNullOrWhiteSpace(commentary);
  }
}
