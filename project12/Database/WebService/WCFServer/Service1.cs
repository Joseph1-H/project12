using Model;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using ViewModel;

namespace WebSservice
{
    public class Service1 : IService1
    {
        //======================================================
        // Admins
        //======================================================
        public AdminsList AdminsSelectAll()
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                AdminsDB adminsDB = new AdminsDB();
                AdminsList adminsList = adminsDB.SelectAll();
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return adminsList;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public AdminsRec AdminsSelect(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                AdminsDB adminsDB = new AdminsDB();
                AdminsRec admin = new AdminsRec { ID = ID };
                admin = (AdminsRec)adminsDB.Select(admin);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return admin;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public bool AdminsInsert(AdminsRec admin)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                AdminsDB adminsDB = new AdminsDB();
                bool result = adminsDB.Insert(admin);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool AdminsUpdate(AdminsRec admin)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                AdminsDB adminsDB = new AdminsDB();
                bool result = adminsDB.Update(admin);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool AdminsDelete(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                AdminsDB adminsDB = new AdminsDB();
                AdminsRec admin = new AdminsRec { ID = ID };
                bool result = adminsDB.Delete(admin);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        //======================================================
        // Comments
        //======================================================
        public CommentsList CommentsSelectAll()
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                CommentsDB commentsDB = new CommentsDB();
                CommentsList commentsList = commentsDB.SelectAll();
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return commentsList;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public CommentsRec CommentsSelect(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                CommentsDB commentsDB = new CommentsDB();
                CommentsRec comment = new CommentsRec { ID = ID };
                comment = (CommentsRec)commentsDB.Select(comment);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return comment;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public bool CommentsInsert(CommentsRec comment)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                CommentsDB commentsDB = new CommentsDB();
                bool result = commentsDB.Insert(comment);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool CommentsUpdate(CommentsRec comment)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                CommentsDB commentsDB = new CommentsDB();
                bool result = commentsDB.Update(comment);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool CommentsDelete(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                CommentsDB commentsDB = new CommentsDB();
                CommentsRec comment = new CommentsRec { ID = ID };
                bool result = commentsDB.Delete(comment);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        //======================================================
        // Exercises
        //======================================================
        public ExercisesList ExercisesSelectAll()
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                ExercisesDB exercisesDB = new ExercisesDB();
                ExercisesList exercisesList = exercisesDB.SelectAll();
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return exercisesList;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public ExercisesRec ExercisesSelect(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                ExercisesDB exercisesDB = new ExercisesDB();
                ExercisesRec exercise = new ExercisesRec { ID = ID };
                exercise = (ExercisesRec)exercisesDB.Select(exercise);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return exercise;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public bool ExercisesInsert(ExercisesRec exercise)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                ExercisesDB exercisesDB = new ExercisesDB();
                bool result = exercisesDB.Insert(exercise);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool ExercisesUpdate(ExercisesRec exercise)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                ExercisesDB exercisesDB = new ExercisesDB();
                bool result = exercisesDB.Update(exercise);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool ExercisesDelete(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                ExercisesDB exercisesDB = new ExercisesDB();
                ExercisesRec exercise = new ExercisesRec { ID = ID };
                bool result = exercisesDB.Delete(exercise);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        //======================================================
        // Likes
        //======================================================
        public LikesList LikesSelectAll()
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                LikesDB likesDB = new LikesDB();
                LikesList likesList = likesDB.SelectAll();
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return likesList;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public LikesRec LikesSelect(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                LikesDB likesDB = new LikesDB();
                LikesRec like = new LikesRec { ID = ID };
                like = (LikesRec)likesDB.Select(like);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return like;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public bool LikesInsert(LikesRec like)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                LikesDB likesDB = new LikesDB();
                bool result = likesDB.Insert(like);    // fixed: use likesDB, not LikesDB.Insert
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool LikesUpdate(LikesRec like)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                LikesDB likesDB = new LikesDB();
                bool result = likesDB.Update(like);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool LikesDelete(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                LikesDB likesDB = new LikesDB();
                LikesRec like = new LikesRec { ID = ID };
                bool result = likesDB.Delete(like);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        //======================================================
        // Passwords
        //======================================================
        public PasswordsList PasswordSelectAll()
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                PasswordsDB passwordsDB = new PasswordsDB();
                PasswordsList passwordsList = passwordsDB.SelectAll();
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return passwordsList;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public PasswordsRec PasswordsSelect(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                PasswordsDB passwordsDB = new PasswordsDB();
                PasswordsRec password = new PasswordsRec { ID = ID };
                password = (PasswordsRec)passwordsDB.Select(password);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return password;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public bool PasswordsInsert(PasswordsRec password)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                PasswordsDB passwordsDB = new PasswordsDB();
                bool result = passwordsDB.Insert(password);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool PasswordsUpdate(PasswordsRec password)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                PasswordsDB passwordsDB = new PasswordsDB();
                bool result = passwordsDB.Update(password);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool PasswordsDelete(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                PasswordsDB passwordsDB = new PasswordsDB();
                PasswordsRec password = new PasswordsRec { ID = ID };
                bool result = passwordsDB.Delete(password);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        //======================================================
        // Posts
        //======================================================
        public PostsList PostsSelectAll()
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                PostsDB postsDB = new PostsDB();
                PostsList postsList = postsDB.SelectAll();
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return postsList;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public PostsRec PostsSelect(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                PostsDB postsDB = new PostsDB();
                PostsRec post = new PostsRec { ID = ID };
                post = (PostsRec)postsDB.Select(post);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return post;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public bool PostsInsert(PostsRec post)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                PostsDB postsDB = new PostsDB();
                bool result = postsDB.Insert(post);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool PostsUpdate(PostsRec post)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                PostsDB postsDB = new PostsDB();
                bool result = postsDB.Update(post);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool PostsDelete(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                PostsDB postsDB = new PostsDB();
                PostsRec post = new PostsRec { ID = ID };
                bool result = postsDB.Delete(post);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        //======================================================
        // Users
        //======================================================
        public UsersList UsersSelectAll()
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                UsersDB usersDB = new UsersDB();
                UsersList usersList = usersDB.SelectAll();
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return usersList;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public UsersRec UsersSelect(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                UsersDB usersDB = new UsersDB();
                UsersRec user = new UsersRec { ID = ID };
                user = (UsersRec)usersDB.Select(user);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return user;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public bool UsersInsert(UsersRec user)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                UsersDB usersDB = new UsersDB();
                bool result = usersDB.Insert(user);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool UsersUpdate(UsersRec user)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                UsersDB usersDB = new UsersDB();
                bool result = usersDB.Update(user);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool UsersDelete(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                UsersDB usersDB = new UsersDB();
                UsersRec user = new UsersRec { ID = ID };
                bool result = usersDB.Delete(user);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        //======================================================
        // Workouts
        //======================================================
        public WorkoutsList WorkoutsSelectAll()
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                WorkoutsDB workoutsDB = new WorkoutsDB();
                WorkoutsList workoutsList = workoutsDB.SelectAll();
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return workoutsList;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public WorkoutsRec WorkoutsSelect(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                WorkoutsDB workoutsDB = new WorkoutsDB();
                WorkoutsRec workout = new WorkoutsRec { ID = ID };
                workout = (WorkoutsRec)workoutsDB.Select(workout);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return workout;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return null;
            }
        }

        public bool WorkoutsInsert(WorkoutsRec workout)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                WorkoutsDB workoutsDB = new WorkoutsDB();
                bool result = workoutsDB.Insert(workout);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool WorkoutsUpdate(WorkoutsRec workout)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                WorkoutsDB workoutsDB = new WorkoutsDB();
                bool result = workoutsDB.Update(workout);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }

        public bool WorkoutsDelete(long ID)
        {
            try
            {
                ViewModel.DB.OpenDatabase();
                WorkoutsDB workoutsDB = new WorkoutsDB();
                WorkoutsRec workout = new WorkoutsRec { ID = ID };
                bool result = workoutsDB.Delete(workout);
                ViewModel.DB.CloseDatabase();
                General.message = DB.Error;
                return result;
            }
            catch (Exception ex)
            {
                General.message = ex.Message;
                return false;
            }
        }
    }
}
