public class SaveCommentaryHandler
{
  private readonly UserRepository userRepository;
  private readonly CommentaryRepository commentaryRepository;

  public SaveCommentaryHandler(
    UserRepository userRepository,
    CommentaryRepository commentaryRepository)
  {
    this.userRepository = userRepository;
    this.commentaryRepository = commentaryRepository;
  }

  public void Execute(SaveCommentaryCommnad command)
  {
    var user = userRepository.getBy(userId: command.userId);
    var commentary = new Comentary(
      userId: command.userId,
      userNick: user.nick,
      pictureId: command.pictureId,
      commentary: command.commentary
    );
    commentaryRepository.save(commnetary);
  }
}
