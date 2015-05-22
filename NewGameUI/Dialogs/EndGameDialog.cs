﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewGameUI.Services.FTP;
using SnakeDeathmatch.Game;

namespace NewGameUI.Dialogs
{
    public partial class EndGameDialog : Form
    {

        private Game _game;
        private bool _restartGame;

        public EndGameDialog()
        {
            InitializeComponent();
        }


        private void EndGameDialog_Load(object sender, EventArgs e)
        {

        }

        public bool OpenDialog(Game game)
        {

            _game = game;
            lblGameStats.Text = game.GameStats;
            _restartGame = false;

            LoadItems(game.Players);

            this.ShowDialog();

            return _restartGame;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var repository = new FTPFileRepository();

            repository.SaveGame(_game, txtFileName.Text);

            MessageBox.Show("Hra uložena", "Uložení hry", MessageBoxButtons.OK);

        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            _restartGame = true;
            this.Hide();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            _restartGame = false;
            this.Hide();
        }

        private void LoadItems(IEnumerable<Player> players)
        {
            var imagelist = new ImageList();
            listPlayers.SmallImageList = imagelist;

            listPlayers.Items.Clear();

            foreach (var player in players.OrderByDescending(x => x.Score))
            {

                var playerIcon = new Bitmap(16, 16);
                using (Graphics graphics = Graphics.FromImage(playerIcon))
                {
                    graphics.Clear(listPlayers.BackColor);
                    var rectangle = new Rectangle(2, 2, 12, 12);
                    graphics.FillEllipse(new SolidBrush((Color)player.Color), rectangle);
                }
                imagelist.Images.Add(player.Identifier.ToString(CultureInfo.InvariantCulture), playerIcon);

                var item = new ListViewItem();
                item.Text = "";
                item.SubItems.Add(player.Score.ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add(player.Name);
                item.SubItems.Add(player.State.ToString());
                item.ImageKey = player.Identifier.ToString(CultureInfo.InvariantCulture);

                listPlayers.Items.Add(item);
            }
        }

    }
}
